const forms = document.querySelectorAll(".product-edit");
forms.forEach((item) => {
    item.addEventListener("submit", (event) => {
        event.preventDefault();
    });
});

$(function () {
    const placeHolderElement = $('#placeHolderHere');


    $('button[data-toggle="ajax-modal"]').click(function (event) {
        const url = $(this).data('url');
        $.get(url).done(function (data) {
            placeHolderElement.html(data);
            placeHolderElement.find('.modal').modal('show');
            console.log(data);
            console.log(url);
            console.log($(this));
        })
    })


}
)

