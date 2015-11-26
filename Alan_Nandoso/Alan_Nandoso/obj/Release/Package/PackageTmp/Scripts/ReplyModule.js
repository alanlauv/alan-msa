// We've sepearated out all the functions related to making the AJAX calls to the API
// Just keeps things tidy, allows us to keep some things private
var ReplyModule = (function () {

    // Return anything that you want to expose outside the closure
    return {
        getReplies: function (callback) {

            $.ajax({
                type: "GET",
                dataType: "json",
                url: "http://alan-nandoso.azurewebsites.net/api/Replies",
                success: function (data) {
                    console.log(data);
                    callback(data);
                }
            });
        }
    };
}());

var SubmitReplyModule = (function () {

    // Return anything that you want to expose outside the closure
    return {
        submitFeedback: function () {

            var name = document.getElementById("feedbackName").value;
            var reply = document.getElementById("feedbackContent").value;
            var date = new Date();
            //var commentID = 

            console.log(Name, Feedback, date);

            $.ajax({
                type: "POST",
                data: JSON.stringify({ Name: name, Body: reply, Date: date }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: "http://alan-nandoso.azurewebsites.net/api/Replies",
                success: function (data) {
                    console.log(data);
                    location.reload();
                }
            });
        }
    };
}());