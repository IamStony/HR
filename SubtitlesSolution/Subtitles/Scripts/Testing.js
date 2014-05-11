
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
        e.Name = "SonjaKul";
        alert("Nafn");
        alert(e.Name);
        e.ImdbUrl = "SonjaURL";
        alert(e.ImdbUrl);
        alert("URL");
        $.post("/Home/Translate", { Object: e }, function () {
            alert("Póst");
        });
        alert("BUIÐ");
        $("#Name").val("");
        $("#ImdbUrl").val("");
    }
}