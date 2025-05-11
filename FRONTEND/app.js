async function ShowCalculations() {
    let loanAmount = document.getElementById("loanAmountInput").value
    let interestRate = document.getElementById("interestRateInput").value

    const response = await fetch("http://localhost:5295/Loan?amount=" + loanAmount + "&interestRate=" + interestRate)
    const cards = await response.json()

    let results = document.getElementById("calculationResults")
    results.replaceChildren()

    cards.map(x => {
        let years = document.createElement("div")
        let repayAmount = document.createElement("div")
        let monthlyRepayment = document.createElement("div")

        years.innerHTML = x.years + " év"
        repayAmount.innerHTML = "Visszafizetendő összeg: " + x.repayAmount + " Ft"
        monthlyRepayment.innerHTML = "Havi törlesztő díj: " + x.interestRate + " Ft"

        let card = document.createElement("div")
        card.appendChild(years)
        card.appendChild(repayAmount)
        card.appendChild(monthlyRepayment)

        if (x.interestRate <= 20000) {
            card.classList.add("bg-success-subtle")
        }
        else if (x.interestRate <= 50000 && x.interestRate > 20000) {
            card.classList.add("bg-warning-subtle")
        }
        else if (x.interestRate > 50000) {
            card.classList.add("bg-danger-subtle")
        }

        card.classList.add("card")

        results.appendChild(card)
    })
}