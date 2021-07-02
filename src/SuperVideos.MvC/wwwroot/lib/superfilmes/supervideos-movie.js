if (typeof SuperVideos == "undefined") {
    SuperVideos = {};
}

SuperVideos.Movie = {
    OnAvailable: (e) => {
        $.post('/Movie/SetAvailable?id=' + e.dataset.id, (r) => {

            SuperVideos.Animation.Toast("Filme Devolvido");

        }).fail((err) => {

            SuperVideos.Animation.Toast("Erro Sistêmico");

        }).done(() => {


        });
    },
    OnSetUnavailable: (e) => {
        $.post('/Movie/SetUnavailable?id=' + e.dataset.id, (r) => {

            SuperVideos.Animation.Toast("Filme Locado");

        }).fail((err) => {

            SuperVideos.Animation.Toast("Erro Sistêmico");

        }).done(() => {


        });
    },
    OnSaveEdit: (e) => {


        e.preventDefault();
        e.stopPropagation();

        let dataForm = new FormData(e.target);

        $.ajax({
            url: 'Movie/Edit',
            method: "POST",
            data: dataForm,
            processData: false,
            contentType: false,
            uploadProgress: (evt, pos, total, percenteComplete) => {

                console.log(percenteComplete);

            },
            success: (r) => {


                SuperVideos.Animation.Toast("Cadastro Realizado");

                $('#form-register-salesman').trigger("reset");

            },
            error: (err) => {

                SuperVideos.Animation.Toast("Erro Sistêmico");

            },
            complete: function (jqXHR, status) {
                console.log(jqXHR);
                console.log(status);
            }
        });
    },
    OnEdit: (e) => {

        debugger;

        $.get('/Movie/Edit?id=' + e.dataset.id, (r) => {

            $("#tab-new-content").html(r);

            SuperVideos.Animation.Show();

            $('#form-edit-movie').submit((e) => {
                SuperVideos.Movie.OnSaveEdit(e);
            });
        });

    },
    OnDelete: (e) => {

        $.post('/Movie/Delete?id=' + e.dataset.id, (r) => {

            SuperVideos.Animation.Toast("Registro Removido");

        }).fail((err) => {

            SuperVideos.Animation.Toast("Erro Sistêmico");

        }).done(() => {


        });

    },
    OnDetails: (e) => { SuperVideos.Animation.Show(); },
    OpenDialogFile: () => {

        $('#picture-movie').trigger('click');
    },
    OpenDialogFileEdit: () => {

        $('#picture-movie-edit').trigger('click');
    }
}