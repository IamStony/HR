
/*$('#yolo').click(function () {
    addcomment();
});
function addcomment() {
    //Ef það er búið að slá eitthvað inn í textaboxið
    if (!$("#Name").val() == "") {
        console.log("Adding comment...");
        //Geyma það sem notandinn skrifar inn
        var e = new Object();
        e.Name = $("#Name").val();
        e.ImdbUrl = $("#ImdbUrl").val();
        //Senda það sem notandinn skrifaði inn og setja það
        //inn í CommentRepository
        $.post('/Home/Translate', { Movie: e }, function () {
            //Sækja svo öll commentin upp á nýtt
        });
        //"Núllstilla" textaboxið
        $("#CommentText").val("");
    }
};*/

$("#yolo").click(function () {
    addcomment()
});

function addcomment() {
    if ($("#Name").val != "") {
        //Consolelog
        //Geyma input frá notanda
        var e = new Object();
        alert("Nýtt object");
        e.Name = $("#Name").val();
        alert("Nafn");
        alert(e.Name);
        e.ImdbUrl = $("#ImdbUrl").val();
        alert(e.ImdbUrl);
        alert("URL");
        $.ajax({
            type: "POST",
            url: "/Home/Translate/",
            data: e,
            dataType: "json",
            success: function (data) {
                alert("Tókst");
            },
        });
        alert("BUIÐ");
        $("#Name").val("");
        $("#ImdbUrl").val("");
    }
    document.getElementById('uploader').onsubmit = function () {
        var formdata = new FormData(); //FormData object
        var fileInput = document.getElementById('fileInput');
        //Iterating through each files selected in fileInput
        for (i = 0; i < fileInput.files.length; i++) {
            //Appending each file to FormData object
            formdata.append(fileInput.files[i].name, fileInput.files[i]);
        }
        //Creating an XMLHttpRequest and sending
        var xhr = new XMLHttpRequest();
        xhr.open('POST', '/Home/Upload');
        xhr.send(formdata);
        xhr.onreadystatechange = function () {
            if (xhr.readyState == 4 && xhr.status == 200) {
                alert(xhr.responseText);
            }
        }
        return false;
    }
}