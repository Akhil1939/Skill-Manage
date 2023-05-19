
var PageNo = 1;
var PageSize = 5;
var Status = "All";
var Sort = "New_to_Old";
var Keyword = ""
SetPagination();
async function ChangePage(e) {
    debugger
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
function SetPagination() {
    document.getElementById(`page-${PageNo}`).parentElement.classList.add('active')
    var First_Page = 1;
    var Last_Page = parseInt($(".page-indexes").last().attr("id").split('-')[1])

    

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