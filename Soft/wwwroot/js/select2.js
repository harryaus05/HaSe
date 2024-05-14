$(".selectItems2").each(function () {

    var $this = $(this),
        selectedId = $this.data('id'),
        controller = $this.data('controller');

    if (selectedId) {
        $.getJSON(`/${controller}/selectItem`, { id: selectedId }, function (data) {
            $this.append(new Option(data.text, data.value, true, true)).trigger('change');
        });
    }

    $this.select2({

        placeholder: `Select a value`,
        theme: "bootstrap4",
        allowClear: true,

        ajax: {
            url: `/${controller}/selectItems`,
            data: function (params) {
                return {
                    searchString: params.term,
                    id: selectedId
                };
            },
            processResults: function (result) {
                return {
                    results: $.map(result, function (item) {
                        return {
                            id: item.value,
                            text: item.text,
                            selected: item.selected
                        };
                    }),
                };
            }
        }
    });

});