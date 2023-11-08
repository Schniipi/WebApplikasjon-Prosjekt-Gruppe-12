document.addEventListener('DOMContentLoaded', function () {
    // Attach event listener for log out link
    var logOutLink = document.getElementById('logOutLink');
    if (logOutLink) {
        logOutLink.addEventListener('click', lagBox);
    }

    // Attach event listener for log out box
    var logoutBox = document.getElementById('logoutBox');
    if (logoutBox) {
        logoutBox.addEventListener('click', function () {
            window.location.href = '/home/Login';
        });
    }
});

function lagBox() {
    var logUtBox = document.getElementById("logoutBox");
    logUtBox.classList.toggle("show");
    console.log(logUtBox);
}