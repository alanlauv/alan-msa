// This event triggers on page load
document.addEventListener("DOMContentLoaded", function () {
    console.log("This works!");
    loadFeedback();
});

function loadFeedback() {
    FeedbackModule.getFeedback(function (feedbackList) {
        ReplyModule.getReplies(function (replyList) {
            setupFeedbackView(feedbackList, replyList);
        });
    });

    function setupFeedbackView(feedbackList, replyList) {
        // We need a reference to the div/table that we are going to chuck our data into
        for (i = 0; i < feedbackList.length; i++) {

            var newFeedbackDiv = $(document.createElement('div')).attr("id", 'FeedbackDiv' + i);

            var htmlCode = '<div class="col-md-2"><a class="btn btn-primary btn-lg btn-block btn-responsive disabled">' +
                feedbackList[i].Name + '</a></div><div class="col-md-8"><a class="btn btn-default btn-lg btn-block btn-responsive disabled">' +
                 feedbackList[i].Body + '</a></div><div class="col-md-2"><button type="submit" class="btn btn-lg btn-block" onclick="replyFeedback(' + feedbackList[i].ID + ')">Reply</button></div>' +
                 '<div class="col-md-12">&nbsp;</div>';

            for (j = 0; j < replyList.length; j++) {
                if (replyList[j].CommentID == feedbackList[i].ID) {
                    htmlCode += '<div class="col-md-1"></div><div class="col-md-2"><a href="#" class="btn btn-success btn-lg btn-block btn-responsive disabled">' +
                    replyList[j].Name + '</a></div><div class="col-md-7"><a href="#" class="btn btn-default btn-lg btn-block btn-responsive disabled">' +
                    replyList[j].Body + '</a></div><div class="col-md-2"></div>' +
                    '<div class="col-md-12">&nbsp;</div>';
                }
            }

            newFeedbackDiv.after().html(htmlCode);

            newFeedbackDiv.appendTo("#feedbackContent");

        }
    }
}

function postFeedback() {
    PostFeedbackModule.submitFeedback();
}

function postReply(commentID, reply) {
    PostReplyModule.submitReply(commentID, reply);
}