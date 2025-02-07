open System
open System.Threading
open System.Threading.Tasks
open computingModule

let rec Menu() =
    printfn "■■■■■■■■■■MENU■■■■■■■■■■"
    printfn "1. Odsetki proste"
    printfn "2. Odsetki składane"
    printfn "3. Raty kredytowe"
    printfn "4. Zysk z lokaty"
    printfn "0. Wyjście\n"
    printf "Wybierz opcję: "

    match Console.ReadLine() with
    | "1" -> 
        printf "\nPodaj kapitał początkowy: "
        let kInput = Console.ReadLine()
        printf "Podaj procent: "
        let pInput = Console.ReadLine()
        printf "Podaj czas: "
        let tInput = Console.ReadLine()

        if String.IsNullOrWhiteSpace(kInput) || String.IsNullOrWhiteSpace(pInput) || String.IsNullOrWhiteSpace(tInput) then
            printfn "\nNie wprowadzono żadnych danych.\n"
            Menu()
        else
            let (successK, k) = Double.TryParse(kInput)
            let (successP, p) = Double.TryParse(pInput)
            let (successT, t) = Double.TryParse(tInput)

            if not (successK && successP && successT) then
                printfn "\nNiewłaściwe dane.\n"
                Menu()
            elif t > 1.0 then
                printfn "\nCzas lokaty musi być mniejszy lub równy 1.\nDla lokat większych niż 1 rok należy obliczać odsetki składane.\n"
                Menu()
            else
                let result = normalPercent(k, p, t)
                printfn "Wynik: %s\n" (String.Format("{0:0.00}", result))
                Menu()
    | "2" ->
        printf "\nPodaj kapitał początkowy: "
        let kInput = Console.ReadLine()
        printf "Podaj procent: "
        let pInput = Console.ReadLine()
        printf "Podaj czas: "
        let tInput = Console.ReadLine()

        if String.IsNullOrWhiteSpace(kInput) || String.IsNullOrWhiteSpace(pInput) || String.IsNullOrWhiteSpace(tInput) then
            printfn "\nNie wprowadzono żadnych danych.\n"
            Menu()
        else
            let (successK, k) = Double.TryParse(kInput)
            let (successP, p) = Double.TryParse(pInput)
            let (successT, t) = Double.TryParse(tInput)

            if not (successK && successP && successT) then
                printfn "\nNiewłaściwe dane.\n"
                Menu()
            elif t < 1 then
                printfn "\nCzas lokaty musi być większy od 1.\nDla lokat mniejszych niż 1 rok należy obliczać odsetki proste.\n" |> ignore
                Menu()
            else
                let result = foldedPercent(k, p, t)
                printfn "Wynik: %s\n" (String.Format("{0:0.00}", result))
                Menu()

    | "3" -> 
        printfn "▓▓▓▓▓▓▓▓▓▓RATY KREDYTOWE▓▓▓▓▓▓▓▓▓▓"
        printfn "W danym podprogramie możesz obliczyć różne raty kredytowe, takie jak malejące lub równe"
        printfn "1. Rata malejąca"
        printfn "2. Rata równa"
        printfn "3. Powrót do menu głównego\n"
        printf "Wybierz opcję: "

        match Console.ReadLine() with
        | "1" ->
            printf "\nPodaj kwotę udzielonego kredytu: "
            let SInput = Console.ReadLine()
            printf "Podaj liczbę rat: "
            let NInput = Console.ReadLine()
            printf "Podaj oprocentowanie kredytu: "
            let rInput = Console.ReadLine()
            printf "Podaj numer raty: "
            let nInput = Console.ReadLine()

            if String.IsNullOrWhiteSpace(SInput) || String.IsNullOrWhiteSpace(NInput) || String.IsNullOrWhiteSpace(rInput) || String.IsNullOrWhiteSpace(nInput) then
                printfn "\nNie wprowadzono żadnych danych. Wracam do menu głównego...\n"
                Menu()
            else
                let (successS, S) = Double.TryParse(SInput)
                let (successN, N) = Double.TryParse(NInput)
                let (successR, r) = Double.TryParse(rInput)
                let (successN, n) = Double.TryParse(nInput)
                if not (successS && successN && successR && successN) then
                    printfn "\nNiewłaściwe dane. Wracam do menu głównego...\n"
                    Menu()
                elif S < 0 || N < 0 || r < 0 || n < 0 then
                    printfn "\nNiektóre wartości są zerowe lub ujemne. Wracam do menu głównego...\n"
                    Menu()
                elif n > N then
                    printfn "\nNumer raty nie może być większy niż liczba rat. Wracam do menu głównego...\n"
                    Menu()
                else
                    let result = RatyModule.RataDecreased(S, N, r, n)
                    printfn "Wynik: %s\n" (String.Format("{0:0.00}", result))
                    Menu()
        | "2" ->
            printf "\nPodaj kwotę udzielonego kredytu: "
            let NInput = Console.ReadLine()
            printf "Podaj oprocentowanie kredytu w skali roku: "
            let rInput = Console.ReadLine()
            printf "Podaj liczbę rat płatnych w ciągu roku: "
            let kInput = Console.ReadLine()
            printf "Podaj ogólną liczbę rat: "
            let nInput = Console.ReadLine()

            if String.IsNullOrWhiteSpace(NInput) || String.IsNullOrWhiteSpace(rInput) || String.IsNullOrWhiteSpace(kInput) || String.IsNullOrWhiteSpace(nInput) then
                printfn "\nNie wprowadzono żadnych danych. Wracam do menu głównego...\n"
                Menu()
            else
                let (successN, N) = Double.TryParse(NInput)
                let (successr, r) = Double.TryParse(rInput)
                let (successk, k) = Double.TryParse(kInput)
                let (successn, n) = Double.TryParse(nInput)
                if not (successN && successr && successk && successn) then
                    printfn "\nNiewłaściwe dane. Wracam do menu głównego...\n"
                    Menu()
                elif N < 0 || r < 0 || k < 0 || n < 0 then
                    printfn "\nNiektóre wartości są zerowe lub ujemne. Wracam do menu głównego...\n"
                    Menu()
                elif k > n then
                    printfn "\nLiczba rat płatnych w ciągu roku jest większa niż ogólna liczba rat. Wracam do menu głównego...\n"
                    Menu()
                else
                    let result = RatyModule.RataEqual(N, r, k, n)
                    printfn "Wynik: %s\n" (String.Format("{0:0.00}", result))
                    Menu()
        | "3" ->
            Menu()
        | _ ->
            printfn "\nNiewłaściwa opcja. Wracam do menu głównego...\n"
            Menu()
    | "4" ->
        printf "\nWpisz typ zysku z lokaty (nominalny lub realny): "
        let typZysku = Console.ReadLine()

        match typZysku.ToLower() with
        | "nominalny" ->
            printf "\nPodaj kwotę inwestycji: "
            let kInput = Console.ReadLine()
            printf "Podaj procent: "
            let pInput = Console.ReadLine()
            printf "Podaj okres trwania lokaty: "
            let cInput = Console.ReadLine()
            printf "Podaj liczbę okresów kapitalizacji: "
            let LkInput = Console.ReadLine()

            if String.IsNullOrWhiteSpace(kInput) || String.IsNullOrWhiteSpace(pInput) || String.IsNullOrWhiteSpace(cInput) || String.IsNullOrWhiteSpace(LkInput) then
                printfn "\nNie wprowadzono żadnych danych.\n"
                Menu()
            else
                let (successK, k) = Double.TryParse(kInput)
                let (successP, p) = Double.TryParse(pInput)
                let (successC, c) = Double.TryParse(cInput)
                let (successLk, Lk) = Double.TryParse(LkInput)
                if not (successK && successP && successC && successLk) then
                    printfn "\nNiewłaściwe dane.\n"
                    Menu()
                else
                    let result = LokatyModule.ZyskNormal(k, p, c)
                    let resultCapitalized = LokatyModule.ZyskNormalCapitalized(k, p, c, Lk)
                    let resultNetto = LokatyModule.ZyskNormalNetto(LokatyModule.ZyskNormalCapitalized(k, p, c, Lk))
                    printfn "\nZysk bez uwzględnienia inflacji wynosi %s" (String.Format("{0:0.00}", result))
                    printfn "Zysk z uwzględnieniem kapitalizacji wynosi %s" (String.Format("{0:0.00}", resultCapitalized))
                    printfn "Zysk netto wynosi %s\n" (String.Format("{0:0.00}", resultNetto))
                    Menu()
        | "realny" ->
            printf "\nPodaj kwotę inwestycji: "
            let kInput = Console.ReadLine()
            printf "Podaj procent: "
            let pInput = Console.ReadLine()
            printf "Podaj okres trwania lokaty: "
            let cInput = Console.ReadLine()
            printf "Podaj wskaźnik inflacji (procentowo): "
            let iInput = Console.ReadLine()

            if String.IsNullOrWhiteSpace(kInput) || String.IsNullOrWhiteSpace(pInput) || String.IsNullOrWhiteSpace(cInput) || String.IsNullOrWhiteSpace(iInput) then
                printfn "\nNie wprowadzono żadnych danych.\n"
                Menu()
            else
                let (successK, k) = Double.TryParse(kInput)
                let (successP, p) = Double.TryParse(pInput)
                let (successC, c) = Double.TryParse(cInput)
                let (successI, i) = Double.TryParse(iInput)
                if not (successK && successP && successC && successI) then
                    printfn "\nNiewłaściwe dane.\n"
                    Menu()
                else
                    let result = LokatyModule.ZyskReal(LokatyModule.ZyskNormal(k, p, c) / k, i)
                    printfn "Zysk realny wynosi %s\n" (String.Format("{0:0.00}", result))
                    Menu()
        | _ ->
            printfn "Niewłaściwa opcja. Wracam do menu głównego...\n"
            Menu()

    | "0" ->
        printfn "\nProgram się zamkni za 5 sekund."
        Thread.Sleep(5000)
        Environment.Exit(0)
    | _ -> 
        printfn "\nNiewłaściwa opcja.\n"
        Menu()

[<EntryPoint>]
let main argv =
    printfn "­­▓▓▓▓▓▓▓▓▓▓KALKULATOR FINANSOWY▓▓▓▓▓▓▓▓▓▓\n"
    Menu()
    0
        