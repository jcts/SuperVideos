if (typeof SuperVideos == "undefined") {
    SuperVideos = {};
}

SuperVideos.Animation = {

    Show: () => {

        var initalLeftMargin = $(".innerLiner").css('margin-left').replace("px", "") * 1;

        var newLeftMargin = (initalLeftMargin - $(".box2")[0].offsetWidth - 4);

        $(".innerLiner").animate({ marginLeft: newLeftMargin }, 500);

    },
    Hide: () => {

        var initalLeftMargin = $(".innerLiner").css('margin-left').replace("px", "") * 1;

        var newLeftMargin = (initalLeftMargin + $(".box1")[0].offsetWidth + 4);

        $(".innerLiner").animate({ marginLeft: newLeftMargin }, 500, () => {

            $("#tab-new-content").empty();
        });

    },
    Toast: (params) => {

        let toast = document.getElementById("toast")
        toast.querySelector('[id="desc"]').innerHTML = params;
        toast.className = "show";
        setTimeout(function () { toast.className = toast.className.replace("show", ""); }, 4900);
    }

}