// Fully scalable analogue and digital clock.

open System.Windows.Forms
open System.Drawing
open System

// Hand type, made to allow pointCalc to create different hand lengths
type Hand = Hour | Minute | Second | Mark

// Double buffering to prevent flickering
type form2 () as this =
    inherit Form()
    do this.DoubleBuffered <- true

// Initialising values used all over program
printfn "How big do you want the clock? (In pixels) Minimum is 50"
let dia =
    let temp =
        try Console.ReadLine() |> int |> Some
        with | exn -> None
    match temp with
    | Some temp -> temp
    | None      -> 0
    
let rad = dia/2
let buff = dia/10
let pi = Math.PI
let mutable mil = float(DateTime.Now.Millisecond)
let mutable sec = float(DateTime.Now.Second)
let mutable min = float(DateTime.Now.Minute)
let mutable hour = float(DateTime.Now.Hour)

let win = new Form ()
win.ClientSize <- Size (dia + 2*buff , dia + 2*buff)

// Setting all values for the digital clock
let digClock = new Label()
win.Controls.Add digClock
digClock.AutoSize <- true
digClock.Location <- Point (rad + buff - 28, rad + buff + rad/2)
digClock.ImageAlign <- ContentAlignment.MiddleCenter
digClock.Text <- DateTime.Now.ToString (" dd/MM/yy\n hh:mm:ss")
digClock.BorderStyle <- BorderStyle.Fixed3D

// Drawing the Clock face
let face (d : int) (e : PaintEventArgs) : unit =
    let pen = new Pen (Color.Black , 5.0f)
    e.Graphics.DrawEllipse (pen , buff , buff , d , d)

// Calculates the end point of the different hands.
// Marks are the little black lines that indicate 5-minute increments
let pointCalc (f : float) (h : Hand) : Point =
    match h with
    | Hour   ->
        let x = buff + rad + int(float(rad/3) * cos(((pi/30.0) * f) - pi/2.0) )
        let y = buff + rad + int(float(rad/3) * sin(((pi/30.0) * f) - pi/2.0) )
        Point (x,y)
    | Minute ->
        let x = buff + rad + int(float(rad - rad/4) * cos(((pi/30.0) * f) - pi/2.0) )
        let y = buff + rad + int(float(rad - rad/4) * sin(((pi/30.0) * f) - pi/2.0) )
        Point (x,y)
    | Second ->
        let x = buff + rad + int(float(rad - buff/3) * cos(((pi/30.0) * f) - pi/2.0) )
        let y = buff + rad + int(float(rad - buff/3) * sin(((pi/30.0) * f) - pi/2.0) )
        Point (x,y)
    | Mark   ->
        let x = buff + rad + int(float(rad) * cos(((pi/30.0) * f) - pi/2.0) )
        let y = buff + rad + int(float(rad) * sin(((pi/30.0) * f) - pi/2.0) )
        Point (x,y)

// Finds the inner start point of all Marks, and draws them
let marker (d : int) (e : PaintEventArgs) : unit =
    let markPen = new Pen (Color.Black)

    let markCalc (deg : int) : Point =
        match deg with
        | deg when deg % 15 = 0 ->
            let x = buff + rad + int(float(rad - buff) * cos(((pi/30.0) * float(deg)) - pi/2.0) )
            let y = buff + rad + int(float(rad - buff) * sin(((pi/30.0) * float(deg)) - pi/2.0) )
            Point (x,y)
        | deg when deg % 5 = 0 ->
            let x = buff + rad + int(float(rad - buff/2) * cos(((pi/30.0) * float(deg)) - pi/2.0) )
            let y = buff + rad + int(float(rad - buff/2) * sin(((pi/30.0) * float(deg)) - pi/2.0) )
            Point (x,y)
        | deg ->
            let x = buff + rad + int(float(rad - buff/3) * cos(((pi/30.0) * float(deg)) - pi/2.0) )
            let y = buff + rad + int(float(rad - buff/3) * sin(((pi/30.0) * float(deg)) - pi/2.0) )
            Point (x,y)
        
    for i = 0 to 59 do
        e.Graphics.DrawLine (markPen , markCalc (i) , pointCalc (float(i)) Mark )

// Creates the different Hands, with different length, color and thickness
let hands (d : int) (e : PaintEventArgs) : unit =
    let secPen = new Pen (Color.Red , 3.0f)
    let minPen = new Pen (Color.Green , 4.0f)
    let hPen = new Pen (Color.Blue , 5.0f)

// To make the hands move in smaller increments, the previous value is added.
// Hours are multiplied by 5 because pointCalc uses increments of 60
    let secP : Point =
        pointCalc(sec + mil/1000.0) Second
    let minP : Point =
        pointCalc(min + sec/60.0) Minute
    let hourP: Point =
        pointCalc(hour * 5.0 + min/60.0) Hour
        
    e.Graphics.DrawLine (hPen , Point (buff + rad , buff + rad) , hourP)
    e.Graphics.DrawLine (minPen , Point (buff + rad , buff + rad) , minP)
    e.Graphics.DrawLine (secPen , Point (buff + rad , buff + rad) , secP)

// Timer created to continually update everything
match dia with
    | dia when dia >= 50 ->
        let timer = new Timer()
        timer.Interval <- 50
        timer.Enabled <- true

// Updating all values, and refreshing them on screen
        timer.Tick.Add (fun e ->
                        sec  <- float(DateTime.Now.Second)
                        min  <- float(DateTime.Now.Minute)
                        hour <- float(DateTime.Now.Hour)
                        mil  <- float(DateTime.Now.Millisecond)
                        digClock.Text <- DateTime.Now.ToString (" dd/MM/yy \n hh:mm:ss ")
                        win.Refresh())

        win.Paint.Add (face dia)
        win.Paint.Add (marker dia)
        win.Paint.Add (hands dia)

        Application.Run win

    | dia when dia = 0 ->
        printfn "Invalid input"
    | dia ->
        printfn "Input too small"
