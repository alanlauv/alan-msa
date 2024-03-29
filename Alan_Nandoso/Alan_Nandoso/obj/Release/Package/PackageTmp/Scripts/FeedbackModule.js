﻿// We've sepearated out all the functions related to making the AJAX calls to the API
// Just keeps things tidy, allows us to keep some things private
var FeedbackModule = (function () {

    // Return anything that you want to expose outside the closure
    return {
        getFeedback: function (callback) {

            $.ajax({
                type: "GET",
                dataType: "json",
                url: "http://alan-nandoso.azurewebsites.net/api/Comments",
                success: function (data) {
                    console.log(data);
                    callback(data);
                }
            });
        }
    };
}());

var PostFeedbackModule = (function () {

    // Return anything that you want to expose outside the closure
    return {
        submitFeedback: function () {

            var name = $("#name").val();
            var feedback = $("#feedbackText").val();
            var date = new Date();

            console.log('feed:' +feedback);

            $.ajax({
                type: "POST",
                data: JSON.stringify({ Name: name, Body: feedback, Date: date }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: "http://alan-nandoso.azurewebsites.net/api/Comments",
                success: function (data) {
                    console.log(data);
                    location.reload();
                }
            });
        }
    };
}());