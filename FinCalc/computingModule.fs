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
        let r_proc = r / 100.0
        let o = (N * r_proc) / (k * (1.0 - ((k / (k + r_proc)) ** n)))
        o


    let RataDecreased (S: float, N: float, r: float, n: float) =
        let o = (S / N) * (1.0 + ((N - n + 1.0) * (r / N) / 100.0))
        o

module LokatyModule =
    let ZyskNormal (k: float, p: float, c: float) =
        let p_proc = p / 100.0
        let o = k * p_proc * c
        o

    let ZyskNormalCapitalized (k: float, p: float, c: float, Lk: float) =
        let p_proc = p / 100.0
        let o = k * ((1.0 + p_proc / Lk) ** (Lk * c)) - k
        o

    let ZyskNormalNetto (n: float) =
        let o = n * 0.81
        o

    let ZyskReal (Zn: float, i: float) = 
        let i_proc = i / 100.0
        let o = ((1.0 + Zn) / (1.0 + i_proc)) - 1.0
        o
