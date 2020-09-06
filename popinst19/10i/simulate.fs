module drones

type drone (pos : float * float, dest : float * float, spd : float) = class
    let mutable pos = pos
    let mutable dest = dest

    let vecLen (x : float, y : float) : float =
        sqrt (x**2.0 + y**2.0)
    let vecScale (x : float, y : float) (scalar : float) : float * float =
        (x * scalar, y * scalar)
    let vecAdd (x1 : float, y1 : float) (x2 : float, y2 : float) : float * float =
        (x1 + x2, y1 + y2)

    member this.position = pos
    member this.sestination = dest
    member this.speed = spd

    member this.isFinished =
        pos = dest


    member this.Fly() =
        let moveVec = (fst dest - fst pos, snd dest - snd pos)
        let moveProp = spd / vecLen moveVec

        if moveProp < 1. then
            pos <- vecAdd pos (vecScale moveVec moveProp)
        else
            pos <- dest


end
