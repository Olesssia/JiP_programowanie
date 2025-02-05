module computingModule

open System.IO

let normalPercent (k: float, p: float, t: float) =
    let o = k * (p / 100.0) * t
    o


