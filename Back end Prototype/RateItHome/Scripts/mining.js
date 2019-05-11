$(document).ready(function () {

    loadSparkline("sparkline_pers_mine", [1, 4, 4, 9, 1,2, 4, 12, 7, 3, 8, 7, 9]);
    loadSparkline("sparkline_pers_review", [1, 2, 3, 2, 7, 3, 4, 2, 7, 5, 8, 7, 9]);
    loadSparkline("sparkline_global_mine", [6, 2, 11, 2, 9, 6, 4, 2, 7, 5, 8, 7, 11]);
    loadSparkline("sparkline_global_review", [1, 1, 5, 2, 1, 1, 4, 2, 7, 1, 1, 7, 9]);
 
    function loadSparkline(idVal, dataset) {
        $("#" + idVal).sparkline(dataset, {
            type: 'line',
            width: '250px',
            height: '95px',
            lineColor: '#7f7f7f',
            lineWidth: 3,
            fillColor: false
        });
    }

    function willProgressBeOverwritten() {
        
        var data = getData();

        if (data.isToxic === true || data.isSevereToxic === true || data.isObscene === true ||
            data.isThreat === true || data.isInsult === true || data.isHate === true || data.isSpam === true) {
            return true;
        }
        return false;
    }

    function getData() {
        var rawCommentId = $("#selected-review-id").val();
        var commentId = parseInt(rawCommentId);
        var isToxic = $("[name=IsToxic]").prop("checked");
        var isSevereToxic = $("[name=IsSevereToxic]").prop("checked");
        var isObscene = $("[name=IsObscence]").prop("checked");
        var isThreat = $("[name=IsThreat]").prop("checked");
        var isInsult = $("[name=IsInsult]").prop("checked");
        var isHate = $("[name=IsIdentityHate]").prop("checked");
        var isSpam = $("[name=Spam]").prop("checked");

        var data = {
            SelectedId: commentId, IsToxic: isToxic, IsSevereToxic: isSevereToxic, IsObscene: isObscene,
            IsThreat: isThreat, IsInsult: isInsult, IsIdentityHate: isHate, IsSpam: isSpam
        };

        return data;
    }

    $("#review").click(function () {

        var data = getData();
        console.log(data);

        var request = $.ajax({
            url: "/Mining/Review/",
            data: JSON.stringify(data),
            method: "POST",
            contentType: 'application/json; charset=utf-8',
            success: function (){
                //Post response & clear selections
            },
            error: function (resp) {
                //Error
                alert (JSON.stringify(resp));
            }
        });

    });

    $("#report-table tr").click(function (e) {

        if ($(this).find(".i-id").text()) {

            if (willProgressBeOverwritten()) {

            }

            $("#selected-review-id").val($(this).find(".i-id").text());
            $("#review-sel-text").text($(this).find(".i-content").text());
            $("#sel-time-added").text($(this).find(".i-time").text());
            $("#sel-review").text($(this).find(".i-review").text());
            $("#report-table").find(".sel-marker").hide();
            $("[name=IsToxic]").prop("checked", false);
            $("[name=IsSevereToxic]").prop("checked", false);
            $("[name=IsObscence]").prop("checked", false);
            $("[name=IsThreat]").prop("checked", false);
            $("[name=IsInsult]").prop("checked", false);
            $("[name=IsIdentityHate]").prop("checked", false);
            $("[name=Spam]").prop("checked", false);
            $(this).find(".sel-marker").toggle();

            if($(".already-voted-marker").val() === "true"){
                $("#already-reviewed").show();
                toggleControls("disabled");
            } else {
                $("#already-reviewed").hide();
                toggleControls();
            }
            
        }
   
    });

    function toggleControls(show) {
        if(show){
            $("[name=IsToxic]").attr("disabled", show);
            $("[name=IsSevereToxic]").attr("disabled", show);
            $("[name=IsObscence]").attr("disabled", show);
            $("[name=IsThreat]").attr("disabled", show);
            $("[name=IsInsult]").attr("disabled", show);
            $("[name=IsIdentityHate]").attr("disabled", show);
            $("[name=IsSpam]").attr("disabled", show);
            $("#review").attr("disabled", show);
        } else {
            $("[name=IsToxic]").removeAttr("disabled");
            $("[name=IsSevereToxic]").removeAttr("disabled");
            $("[name=IsObscence]").removeAttr("disabled");
            $("[name=IsThreat]").removeAttr("disabled");
            $("[name=IsInsult]").removeAttr("disabled");
            $("[name=IsIdentityHate]").removeAttr("disabled");
            $("[name=IsSpam]").removeAttr("disabled");
            $("#review").removeAttr("disabled");
        }
    }

});


