
var PageNo = 1;
var PageSize = 6;
var Status = "All";
var Sort = "New_to_Old";
var Keyword = "";

//(async () => {
//    await SetPreserveFilter();
//});
SetPagination();
SetPreserveFilter();
async function ChangePage(e) {
    PageNo = parseInt(e.id.split('-')[1]);
    await FilterSkill()
    SetPagination();
}

async function previousPage() {
    PageNo = PageNo - 1;
    await FilterSkill();
    SetPagination()
}
async function nextPage() {
    PageNo = PageNo + 1;
    await FilterSkill();
    SetPagination()
}

async function FilterSkill() {
    await SetLocalData()
    await $.ajax({
        url: `SkillFilter`,
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify({
            PageNo,
            PageSize,
            Status,
            Sort,
            Keyword
        }),
        success: function (data) {
            document.getElementById("Skill_List").innerHTML = data
        },
        error: function (err) {
            console.log(err)
        }
    })
}

async function SearchSkill(e) {
    Keyword = e.value;
    PageNo = 1;
    await FilterSkill();
    SetPagination();
}

async function ApplySorting(e) {
    Sort = e.value;
    PageNo = 1;
    await FilterSkill();
    SetPagination();
}

async function ApplyStatus(e) {
    Status = e.value;
    PageNo = 1;
    await FilterSkill();
    SetPagination();
}
async function ApplyPageSize(e) {
    PageSize = e.value;
    PageNo = 1;
    await FilterSkill();
    SetPagination();
}

function SetPagination() {
    document.getElementById(`page-${PageNo}`).parentElement.classList.add('active')
    var First_Page = 1;
    var Last_Page = parseInt($(".page-indexes").last().attr("id").split('-')[1])
    if (First_Page != Last_Page) {

        if (PageNo == First_Page) {
            $("#previous")[0].classList.add('d-none');
        } else {
            if ($("#previous").hasClass("d-none")) {
                $("#previous")[0].classList.remove('d-none');
            }
        }

        if (PageNo == Last_Page) {
            $("#next")[0].classList.add('d-none');
        }
        else {
            if ($("#next").hasClass("d-none")) {
                $("#next")[0].classList.remove('d-none');
            }
        }
    }

}

async function SetLocalData() {
    debugger
    await localStorage.setItem("PageNo", PageNo);
    await localStorage.setItem("PageSize", PageSize);
    await localStorage.setItem("Keyword", Keyword);
    await localStorage.setItem("Sort", Sort);
    await localStorage.setItem("Status", Status);

}
async function SetPreserveFilter() {

    if (localStorage.getItem("PageNo") != null) {
        PageNo = parseInt(localStorage.getItem("PageNo"));

    }

    if (localStorage.getItem("PageSize") != null) {
        PageSize = parseInt(localStorage.getItem("PageSize"));
        document.getElementById("FilterPageSize").value = PageSize;
    }

    if (localStorage.getItem("Keyword") != null) {
        Keyword = localStorage.getItem("Keyword");
        document.getElementById("FilterKeyword").value = Keyword;
    }

    if (localStorage.getItem("Sort") != null) {
        Sort = localStorage.getItem("Sort");
        document.getElementById("FilterSort").value = Sort;
    }

    if (localStorage.getItem("Status") != null) {
        Status = localStorage.getItem("Status");
        document.getElementById("FilterPageStatus").value = Status;
    }

    await FilterSkill();
    SetPagination();

}

async function ClearFilter() {
    debugger
    await SetDefault();
    await SetLocalData();
    await SetPreserveFilter();
    SetPagination();
}
function SetDefault() {
    PageNo = 1;
    PageSize = 6;
    Status = "All";
    Sort = "New_to_Old";
    Keyword = "";
}