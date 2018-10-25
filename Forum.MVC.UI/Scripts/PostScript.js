function LikeFunc(postId, userID) {
    $.ajax({
        type: "POST",
        url: "/Post/LikePost?postId=" + postId + "&userID=" + userID,
        contentType: "html",
        success: function (result) {
            var score = $('#score-' + postId).html();
            switch (result) {
                case "1":
                    score++;
                    var votes = $('#postVotes-' + postId).html();
                    votes++;
                    $('#score-' + postId).html(score);
                    $('#postVotes-' + postId).html(votes);
                    $('#likeButton-' + postId).css("color", "lightgreen");
                    $('#dislikeButton-' + postId).css('color', 'lightgray');
                    break;
                case "2":
                    score++;
                    score++;
                    $('#score-' + postId).html(score);
                    $('#likeButton-' + postId).css("color", "lightgreen");
                    $('#dislikeButton-' + postId).css('color', 'lightgray');
                    break;
                case "3":
                    score++;
                    $('#score-' + postId).html(score);
                    $('#likeButton-' + postId).css("color", "lightgreen");
                    $('#dislikeButton-' + postId).css('color', 'lightgray');
                    break;
                case "4":
                    score--;
                    $('#score-' + postId).html(score);
                    $('#likeButton-' + postId).css("color", "lightgray");
                    $('#dislikeButton-' + postId).css('color', 'lightgray');
                    break;
                case "5":
                    alert("Failed ! ! !");
                    break;
            }
        }
    });
}

function LikeCommentFunc(commentId, userID) {
    $.ajax({
        type: "POST",
        url: "/Post/LikeComment?commentId=" + commentId + "&userID=" + userID,
        contentType: "html",
        success: function (result) {
            var score = $('#commentScore-' + commentId).html();
            switch (result) {
                case "1":
                    score++;
                    $('#commentScore-' + commentId).html(score);
                    $('#likeComment-' + commentId).css("color", "lightgreen");
                    $('#dislikeComment-' + commentId).css('color', 'lightgray');
                    break;
                case "2":
                    score++;
                    score++;
                    $('#commentScore-' + commentId).html(score);
                    $('#likeComment-' + commentId).css("color", "lightgreen");
                    $('#dislikeComment-' + commentId).css('color', 'lightgray');
                    break;
                case "3":
                    score++;
                    $('#commentScore-' + commentId).html(score);
                    $('#likeComment-' + commentId).css("color", "lightgreen");
                    $('#dislikeComment-' + commentId).css('color', 'lightgray');
                    break;
                case "4":
                    score--;
                    $('#commentScore-' + commentId).html(score);
                    $('#likeComment-' + commentId).css("color", "lightgray");
                    $('#dislikeComment-' + commentId).css('color', 'lightgray');
                    break;
                case "5":
                    alert("Failed ! ! !");
                    break;
            }
        }
    });
}

function LikeReplyFunc(replyId, userID) {
    $.ajax({
        type: "POST",
        url: "/Post/LikeReply?replyId=" + replyId + "&userID=" + userID,
        contentType: "html",
        success: function (result) {
            var score = $('#replyScore-' + replyId).html();
            switch (result) {
                case "1":
                    score++;
                    $('#replyScore-' + replyId).html(score);
                    $('#likeReply-' + replyId).css("color", "lightgreen");
                    $('#dislikeReply-' + replyId).css('color', 'lightgray');
                    break;
                case "2":
                    score++;
                    score++;
                    $('#replyScore-' + replyId).html(score);
                    $('#likeReply-' + replyId).css("color", "lightgreen");
                    $('#dislikeReply-' + replyId).css('color', 'lightgray');
                    break;
                case "3":
                    score++;
                    $('#replyScore-' + replyId).html(score);
                    $('#likeReply-' + replyId).css("color", "lightgreen");
                    $('#dislikeReply-' + replyId).css('color', 'lightgray');
                    break;
                case "4":
                    score--;
                    $('#replyScore-' + replyId).html(score);
                    $('#likeReply-' + replyId).css("color", "lightgray");
                    $('#dislikeReply-' + replyId).css('color', 'lightgray');
                    break;
                case "5":
                    alert("Failed ! ! !");
                    break;
            }
        }
    });
}

function DislikeFunc(postId, userID) {
    $.ajax({
        type: "POST",
        url: "/Post/DislikePost?postId=" + postId + "&userID=" + userID,
        contentType: "html",
        success: function (result) {
            var score = $('#score-' + postId).html();
            switch (result) {
                case "1":
                    score--;
                    var votes = $('#postVotes-' + postId).html();
                    votes++;
                    $('#score-' + postId).html(score);
                    $('#postVotes-' + postId).html(votes);
                    $('#dislikeButton-' + postId).css("color", "red");
                    $('#likeButton-' + postId).css('color', 'lightgray');
                    break;
                case "2":
                    score--;
                    score--;
                    $('#score-' + postId).html(score);
                    $('#likeButton-' + postId).css("color", "lightgray");
                    $('#dislikeButton-' + postId).css('color', 'red');
                    break;
                case "3":
                    score--;
                    $('#score-' + postId).html(score);
                    $('#likeButton-' + postId).css("color", "lightgray");
                    $('#dislikeButton-' + postId).css('color', 'red');
                    break;
                case "4":
                    score++;
                    $('#score-' + postId).html(score);
                    $('#likeButton-' + postId).css("color", "lightgray");
                    $('#dislikeButton-' + postId).css('color', 'lightgray');
                    break;
                case "5":
                    alert("Failed ! ! !");
                    break;
            }
        }
    });
}

function DislikeCommentFunc(commentId, userID) {
    $.ajax({
        type: "POST",
        url: "/Post/DislikeComment?commentId=" + commentId + "&userID=" + userID,
        contentType: "html",
        success: function (result) {
            var score = $('#commentScore-' + commentId).html();
            switch (result) {
                case "1":
                    score--;
                    $('#commentScore-' + commentId).html(score);
                    $('#dislikeComment-' + commentId).css("color", "red");
                    $('#likeComment-' + commentId).css('color', 'lightgray');
                    break;
                case "2":
                    score--;
                    score--;
                    $('#commentScore-' + commentId).html(score);
                    $('#likeComment-' + commentId).css("color", "lightgray");
                    $('#dislikeComment-' + commentId).css('color', 'red');
                    break;
                case "3":
                    score--;
                    $('#commentScore-' + commentId).html(score);
                    $('#likeComment-' + commentId).css("color", "lightgray");
                    $('#dislikeComment-' + commentId).css('color', 'red');
                    break;
                case "4":
                    score++;
                    $('#commentScore-' + commentId).html(score);
                    $('#likeComment-' + commentId).css("color", "lightgray");
                    $('#dislikeComment-' + commentId).css('color', 'lightgray');
                    break;
                case "5":
                    alert("Failed ! ! !");
                    break;
            }
        }
    });
}

function DislikeReplyFunc(replyId, userID) {
    $.ajax({
        type: "POST",
        url: "/Post/DislikeReply?replyId=" + replyId + "&userID=" + userID,
        contentType: "html",
        success: function (result) {
            var score = $('#replyScore-' + replyId).html();
            switch (result) {
                case "1":
                    score--;
                    $('#replyScore-' + replyId).html(score);
                    $('#dislikeReply-' + replyId).css("color", "red");
                    $('#likeReply-' + replyId).css('color', 'lightgray');
                    break;
                case "2":
                    score--;
                    score--;
                    $('#replyScore-' + replyId).html(score);
                    $('#likeReply-' + replyId).css("color", "lightgray");
                    $('#dislikeReply-' + replyId).css('color', 'red');
                    break;
                case "3":
                    score--;
                    $('#replyScore-' + replyId).html(score);
                    $('#likeReply-' + replyId).css("color", "lightgray");
                    $('#dislikeReply-' + replyId).css('color', 'red');
                    break;
                case "4":
                    score++;
                    $('#replyScore-' + replyId).html(score);
                    $('#likeReply-' + replyId).css("color", "lightgray");
                    $('#dislikeReply-' + replyId).css('color', 'lightgray');
                    break;
                case "5":
                    alert("Failed ! ! !");
                    break;
            }
        }
    });
}

function SubmitComment(e, id) {
    if (e.keyCode === 13) {
        $.ajax({
            type: "POST",
            url: "/Post/PostAComment?postId=" + id + "&comment=" + $('#mainComment').val(),
            contentType: "html",
            success: window.location.reload(true)
        });
    }
}

function SubmitReply(e, id) {
    if (e.keyCode === 13) {
        $.ajax({
            type: "POST",
            url: "/Post/PostAReply?commentId=" + id + "&reply=" + $('#reply-'+id).val(),
            contentType: "html",
            success: window.location.reload(true)
        });
    }
}

function SolvedPost(postId) {
    $.ajax({
        type: "POST",
        url: "/Post/SolvedPost?postId=" + postId,
        contentType: "html",
        success: window.location.reload(true)
    });
}

function SolvedComment(commentId) {
    $.ajax({
        type: "POST",
        url: "/Post/SolvedComment?commentId=" + commentId,
        contentType: "html",
        success: window.location.reload(true)
    });
}


