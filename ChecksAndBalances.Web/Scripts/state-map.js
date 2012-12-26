(function ($) {
    $(document).ready(function () {
        var $statelist, $usamap, ratio,
        default_options =
        {
            fillOpacity: 0.5,
            render_highlight: {
                fillColor: '2aff00',
                stroke: true,
                altImage: '/Content/Images/usa-alt.jpg'
            },
            render_select: {
                fillColor: 'ff000c',
                stroke: false,
                altImage: '/Content/Images/usa-alt.jpg'
            },
            fadeInterval: 50,
            isSelectable: true,
            singleSelect: false,
            mapKey: 'data-state',
            mapValue: 'data-full',
            listKey: 'name',
            listSelectedAttribute: 'checked',
            sortList: "asc",
            onClick: function (e) {
                $("#SelectedState").find('option[value="' + e.key + '"]').attr('selected', true);
                $('#stateForm').submit();
            },
            showToolTip: false,
        };

        $usamap = $('#usa_image');

        $.mapster.impl.init();
        $usamap.mapster(default_options);


    });
})(jQuery);