
var PageNo = 1;
var PageSize = 5;
var Status = "All";
var Sort = "New_to_Old";
var Keyword = ""

function ChangePage(e) {
    debugger
    PageNo = parseInt(e.id.split('-')[1]);
    FilterSkill()
}

$("#previous").click(function () {
    PageNo = PageNo - 1;
    FilterSkill()
})
$("#next").click(function () {
    PageNo = PageNo + 1;
    FilterSkill()
})

function FilterSkill() {
    $.ajax({
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