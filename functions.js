function summarizeButton() {
    // Needs API call here
    // Making it so that when the button is clicked, the summary API is called + the rest of the page will show
    document.getElementById("title").innerHTML = "Summarized Content Below:"
    document.getElementById("approveButton").innerHTML = "<button onclick='splitToMedias()'>Approve of the Summary?</button>"
    document.getElementById("denyButton").innerHTML = "<button onclick='summarizeButton()'>Summary Denied; Try Again?</button>"
}

function spitToMedias() {
    // When clicked, this button will enable user to approve the summary that was given to them,
    // and put the summary out onto different media platforms (Slack, Twitter, etc.)
}