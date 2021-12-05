$(function () {
    const placeHolderElement = $('#placeHolderHere');

    $('button[data-toggle="ajax-modal"]').click(function (event) {
        const url = $(this).data('url');
        $.get(url).done(function (data) {
            placeHolderElement.html(data);
            placeHolderElement.find('.modal').modal('show');
        })
    })
}
)

