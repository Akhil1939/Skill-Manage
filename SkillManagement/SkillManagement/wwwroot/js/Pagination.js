$("#page-1").parent()[0].classList.add("active")
$("#previous")[0].classList.add('d-none');
$(".page-item").click(function (e) {
    

    $(".active")[0].classList.remove("active")
    var Target = e.target;
    var First_Page = parseInt($(".page-indexes").first().attr("id").split('-')[1])
    var Last_Page = parseInt($(".page-indexes").last().attr("id").split('-')[1])
    if (parseInt(Target.id.split('-')[1]) == First_Page) {
        $("#previous")[0].classList.add('d-none');
    } else {
        if ($("#previous").hasClass("d-none")) {
            $("#previous")[0].classList.remove('d-none');
        }
    }

    if (parseInt(Target.id.split('-')[1]) == Last_Page) {
        $("#next")[0].classList.add('d-none');
    }
    else {
        if ($("#next").hasClass("d-none")) {
            $("#next")[0].classList.remove('d-none');
        }
    }
    e.target.parentElement.classList.add("active")
})

function nextPage() {
    debugger
    $(".active")[0].nextElementSibling.classList.add('active');
    $(".active")[0].classList.remove("active")
    var Target = document.getElementsByClassName("active")[0];
    var First_Page = parseInt($(".page-indexes").first().attr("id").split('-')[1])
    var Last_Page = parseInt($(".page-indexes").last().attr("id").split('-')[1])
    if (parseInt(Target.children[0].id.split('-')[1]) == First_Page) {
        $("#previous")[0].classList.add('d-none');
    } else {
        if ($("#previous").hasClass("d-none")) {
            $("#previous")[0].classList.remove('d-none');
        }
    }

    if (parseInt(Target.children[0].id.split('-')[1]) == Last_Page) {
        $("#next")[0].classList.add('d-none');
    }
    else {
        if ($("#next").hasClass("d-none")) {
            $("#next")[0].classList.remove('d-none');
        }
    }
}

function previousPage() {
    $(".active")[0].previousElementSibling.classList.add('active');
    $(".active")[1].classList.remove("active")
    var Target = document.getElementsByClassName("active")[0];
    var First_Page = parseInt($(".page-indexes").first().attr("id").split('-')[1])
    var Last_Page = parseInt($(".page-indexes").last().attr("id").split('-')[1])
    if (parseInt(Target.children[0].id.split('-')[1]) == First_Page) {
        $("#previous")[0].classList.add('d-none');
    } else {
        if ($("#previous").hasClass("d-none")) {
            $("#previous")[0].classList.remove('d-none');
        }
    }

    if (parseInt(Target.children[0].id.split('-')[1]) == Last_Page) {
        $("#next")[0].classList.add('d-none');
    }
    else {
        if ($("#next").hasClass("d-none")) {
            $("#next")[0].classList.remove('d-none');
        }
    }
}


function setActivePage(Target) {
    var First_Page = parseInt($(".page-indexes").first().attr("id").split('-')[1])
    var Last_Page = parseInt($(".page-indexes").last().attr("id").split('-')[1])
    if (parseInt(Target.id.split('-')[1]) == First_Page) {
        $("#previous")[0].classList.add('d-none');
    } else {
        if ($("#previous").hasClass("d-none")) {
            $("#previous")[0].classList.remove('d-none');
        }
    }

    if (parseInt(Target.id.split('-')[1]) == Last_Page) {
        $("#next")[0].classList.add('d-none');
    }
    else {
        if ($("#next").hasClass("d-none")) {
            $("#next")[0].classList.remove('d-none');
        }
    }
}