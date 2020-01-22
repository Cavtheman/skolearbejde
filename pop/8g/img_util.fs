module ImgUtil

open System.Drawing
open System.Windows.Forms

type SmoothForm() as x =  // Thanks to Janro
    inherit Form()
    do x.DoubleBuffered <- true

// colors
type color = System.Drawing.Color
let red : color = Color.Red
let blue : color = Color.Blue
let green : color = Color.Green
let fromRgb (r:int,g:int,b:int) : color =
  Color.FromArgb(255,r,g,b)
let fromArgb (a:int,r:int,g:int,b:int) : color =
  Color.FromArgb(a,r,g,b)

let format = Imaging.PixelFormat.Format24bppRgb

// bitmaps
type bitmap = System.Drawing.Bitmap
let mk h w : bitmap = new Bitmap (h, w, format)
let setPixel (c: color) (x,y) (bmp:bitmap) : unit = bmp.SetPixel (x,y,c)
let setLine (c: color) (x1:int,y1:int) (x2:int,y2:int) (bmp:bitmap) : unit =
  let graphics = Graphics.FromImage(bmp)
  let pen = new Pen(c)
  in graphics.DrawLine(pen, x1, y1, x2, y2);

let setBox c (x1,y1) (x2,y2) bmp =
  do setLine c (x1,y1) (x2,y1) bmp
  do setLine c (x2,y1) (x2,y2) bmp
  do setLine c (x2,y2) (x1,y2) bmp
  do setLine c (x1,y2) (x1,y1) bmp

// read a bitmap file
let fromFile (fname : string) : bitmap =
  new Bitmap(fname)

// save a bitmap as a png file
let toPngFile (fname : string) (b: bitmap) : unit =
  b.Save(fname, Imaging.ImageFormat.Png) |> ignore

let bitmap_of (f:bitmap -> unit) (r:Rectangle) : bitmap =
  let bitmap = new Bitmap (r.Width, r.Height, format)
  do f bitmap
  bitmap

let redraw (g:Rectangle -> bitmap) (b:bitmap ref) (w: #Form) _ =
  do b := g w.ClientRectangle
  do w.Invalidate()

let paint (b:bitmap ref) (v: #Form) (e:PaintEventArgs) =
  let r = e.ClipRectangle
  e.Graphics.DrawImage(!b,r,r,GraphicsUnit.Pixel)

// show bitmap in a gui
let show (t: string) (bmp:bitmap) : unit =
  let h = bmp.Height
  let w = bmp.Width
  let form = new SmoothForm (Visible=true,Text=t,Height=h,Width=w)
  do form.Paint.Add(paint (ref bmp) form)
  do Application.Run form

type KeyEventArgs = System.Windows.Forms.KeyEventArgs

// start an app that can listen to key-events
let runApp (t:string) (w:int) (h:int)
           (f:int -> int -> 's -> bitmap)
           (onKeyDown: 's -> KeyEventArgs -> 's option) (s:'s) : unit =
  let form = new SmoothForm (Visible=true,Text=t,Width=w,Height=h)
  let state = ref s
  let g (r:Rectangle) : bitmap = f r.Width r.Height (!state)
  let bitmap = ref (f w h (!state))
  form.Resize.Add(redraw g bitmap form)
  form.Paint.Add(paint bitmap form)
  form.KeyDown.Add(fun e -> if e.KeyCode = Keys.Escape then form.Close()
                            else match onKeyDown (!state) e with
                                   | None -> ()
                                   | Some s -> (state := s; redraw g bitmap form ()))
  Application.Run form

let runSimpleApp t w h (f:bitmap->unit) : unit =
  runApp t w h (fun w h () ->
                  let bitmap = new Bitmap (w, h, format)
                  do f bitmap
                  bitmap)
               (fun _ _ -> None) ()
