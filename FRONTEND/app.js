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

        years.innerHTML = "<h4>" + x.years + " év" + "</h4>"
        repayAmount.innerHTML = "<b>Visszafizetendő összeg:</b> " + "<br>" + x.repayAmount.toLocaleString() + " Ft"
        monthlyRepayment.innerHTML = "<b>Havi törlesztő díj:</b> " + "<br>" + x.interestRate.toLocaleString() + " Ft"

        let card = document.createElement("div")
        card.appendChild(years)
        card.appendChild(repayAmount)
        card.appendChild(monthlyRepayment)

        if (x.interestRate <= 45000) {
            card.classList.add("bg-success-subtle")
        }
        else if (x.interestRate <= 100000 && x.interestRate > 45000) {
            card.classList.add("bg-warning-subtle")
        }
        else if (x.interestRate > 100000) {
            card.classList.add("bg-danger-subtle")
        }

        card.classList.add("card")
        card.classList.add("cardResults")

        results.appendChild(card)
    })
}