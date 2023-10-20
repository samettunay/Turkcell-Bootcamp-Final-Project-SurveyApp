$(document).ready(function () {
    $('.type').on('click', function () {
        let id = $(this).data('id');
        $.ajax({
            url: 'Surveys/GetSurveysByTypeId',
            type: 'GET',
            data: { surveyTypeId: id },
            success: function (partialHtml) {
                var surveyListDiv = $('#surveyList');
                surveyListDiv.html(partialHtml);
            },
            error: function (err) {
                console.log('hata', error);
            }
        });
    });
});
