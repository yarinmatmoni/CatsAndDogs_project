
$(function () {

    $('form').submit(function (e) {
        e.preventDefault();
        var query = $('#date_s').val();

        $.ajax({
            url: '/AdoptionDays/Search',
            data: { 'queryDate': query }
        }).done(function (data) {

            $('tbody').html('');
            var template = $('#hidden-template').html();

            $.each(data, function (i, val) {
                var temp = template;
                $.each(val, function (key, value) {
                    temp = temp.replaceAll('{' + key + '}', value);
                });
                $('tbody').append(temp);
            });

        });

    });
});