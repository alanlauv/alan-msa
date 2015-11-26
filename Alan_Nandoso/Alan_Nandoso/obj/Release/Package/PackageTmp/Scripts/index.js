// This event triggers on page load
document.addEventListener("DOMContentLoaded", function () {
    console.log("This works!");
    loadFeedback();
    //loadReplies();
});

function loadFeedback() {
    FeedbackModule.getFeedback(function (feedbackList) {
        ReplyModule.getReplies(function (replyList) {
            setupFeedbackView(feedbackList, replyList);
        });
    });

    function setupFeedbackView(feedbackList, replyList) {
        // We need a reference to the div/table that we are going to chuck our data into
        var feedbackContent = document.getElementById("feedbackContent");
        for (i = 0; i < feedbackList.length; i++) {

            var newFeedbackDiv = $(document.createElement('div')).attr("id", 'FeedbackDiv' + i);

            var htmlCode = '<div class="col-md-2"><a class="btn btn-primary btn-lg btn-block btn-responsive disabled">' +
                feedbackList[i].Name + '</a></div><div class="col-md-8"><a class="btn btn-default btn-lg btn-block btn-responsive disabled">' +
                 feedbackList[i].Body + '</a></div><div class="col-md-2"><button type="submit" class="btn btn-lg btn-block">Reply</button></div>' +
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

function loadReplies() {


    ReplyModule.getReplies(function (repliesList) {
        setupRepliesTable(repliesList);
    });

    function setupRepliesTable(Replies) {
        // We need a reference to the div/table that we are going to chuck our data into
        var RepliesTable = document.getElementById("tblreplycontent");
        for (i = 0; i < Replies.length; i++) {

            // Create row 
            var row = document.createElement('tr');

            // Add the columns in the row (td / data cells)
            var idcol = document.createElement('td');
            idcol.innerHTML = Replies[i].Feedback_ID;
            row.appendChild(idcol);

            var replycol = document.createElement('td');
            replycol.innerHTML = Replies[i].Reply;
            row.appendChild(replycol);

            var replydatecol = document.createElement('td');
            replydatecol.innerHTML = Replies[i].ReplyDate;
            row.appendChild(replydatecol);



            // Append the row to the end of the table
            RepliesTable.appendChild(row);

        }
    }
}
function postReply() {
    SubmitReplyModule.submitReplies();



}