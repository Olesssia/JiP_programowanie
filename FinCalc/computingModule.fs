module computingModule

open System.IO

let normalPercent (k: float, p: float, t: float) =
    let o = k * (p / 100.0) * t
    o


let foldedPercent (k: float, p: float, n: float) =
    let o = k * ((1.0 + (p / 100.0)) ** n)
    o

module RatyModule = 
    let RataEqual (N: float, r: float, k: float, n: float) =
        let o = ((N * r) / (k * (1.0 - (k / ((k + r) ** n)))))
        o

    let RataDecreased (S: float, N: float, r: float, n: float) =
        let o = (S / N) *  (1.0 + ((N - n + 1.0) * r))
        o