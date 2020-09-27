// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    $(document).on('click', 'img', function () {
        if ($('#divImg').length > 0) {
            $('#divImg').find('img').remove();
        }
        var imgPath = $(this).prop('src').replace('@($"{Context.Request.Scheme}://{Context.Request.Host}")', '');
        $('#divImg').append('<img id="modalImg" src=' + imgPath + ' Alt="Img" />');
        $('#myModal').modal('show')
    });

    $(document).on('click', '#btnDelete', function () {

        Swal.fire({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.value) {

                $.ajax({
                    url: "@Url.Action("DeleteConfirmed")",
                    type: "post",
                    data: { 'id': $(this).attr('name') },
                    success: function (response) {
                        Swal.fire({
                            title: 'Deleting item',
                            html: '<b></b> milliseconds left.',
                            timer: 1000,
                            timerProgressBar: true,
                            onBeforeOpen: () => {
                                Swal.showLoading()
                                timerInterval = setInterval(() => {
                                    const content = Swal.getContent()
                                    if (content) {
                                        const b = content.querySelector('b')
                                        if (b) {
                                            b.textContent = Swal.getTimerLeft();
                                        }
                                    }
                                }, 100)
                            },
                            onClose: () => {
                                clearInterval(timerInterval)
                            }
                        })
                        setTimeout(function () {
                            location.reload();
                        }, 1000);
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        console.log(textStatus, errorThrown);
                    }

                });
            }
        })
    });

})
