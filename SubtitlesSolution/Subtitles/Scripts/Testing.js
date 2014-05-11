$('#yolo').click(function () {
    addcomment();
});
function addcomment() {
    //Ef það er búið að slá eitthvað inn í textaboxið
    if (!$("#Name").val() == "") {
        console.log("Adding comment...");
        //Geyma það sem notandinn skrifar inn
        var e = $("#Name").val();
        //Senda það sem notandinn skrifaði inn og setja það
        //inn í CommentRepository
        $.post('/Home/Translate', { Movie: e }, function () {
            //Sækja svo öll commentin upp á nýtt
            getallcomments();
        });
        //"Núllstilla" textaboxið
        $("#CommentText").val("");
    }
};