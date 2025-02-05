open System
open System.Threading
open System.Threading.Tasks
open computingModule

let rec Menu() =
    printfn "■■■■■■■■■■MENU■■■■■■■■■■"
    printfn "1. Odsetki proste"
    printfn "2. Odsetki składane"
    printfn "3. Wyjście\n"
    printf "Wybierz opcję: "

    match Console.ReadLine() with
    | "1" -> 
        printfn "Podaj kapitał początkowy: "
        let k = Console.ReadLine() |> float
        printfn "Podaj procent: "
        let p = Console.ReadLine() |> float
        printfn "Podaj czas: "
        let t = Console.ReadLine() |> float

        if t > 1 then
            printfn "Czas lokaty musi być mniejszy lub równy 1.\nDla lokat większych niż 1 rok należy obliczać odsetki składane.\n" |> ignore
            Menu()
        else
            let result = normalPercent(k, p, t)
            printfn "Wynik: %s" (String.Format("{0:0.00}", result))
        Menu()
    | "2" ->
        printfn "coming soon....................................................\n"
        Menu()
    | "3" -> 
        printfn "Program się zamkni za 5 sekund."
        Thread.Sleep(5000)
        Environment.Exit(0)
    | _ -> 
        printfn "Niewłaściwa opcja.\n"
        Menu()

[<EntryPoint>]
let main argv =
    Menu()
    0
        