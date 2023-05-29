// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function HideMessage() {
   
    if ($(".alert").length > 0) {
        $(".alert").remove();
    }
}

(() => {
    setInterval("HideMessage()", 3000)
})()

function Logout() {
    debugger
    localStorage.clear();
    $.ajax({
        url: '/Auth/Logout',
        type: 'post',
        success: function (data) {
            window.location.href = "/";
        },
        error: function (err) {
            console.log(err)
        }
    })
}