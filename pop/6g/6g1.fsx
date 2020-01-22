let rec float2cfrac (x : float) : (int list) =
    if -0.00001 < (x - floor(x)) && (x - floor(x)) < 0.00001 then
        []
    else
        int(floor(x+0.00001)) :: float2cfrac (1.0 / (x - floor(x)))

float2cfrac 3.
