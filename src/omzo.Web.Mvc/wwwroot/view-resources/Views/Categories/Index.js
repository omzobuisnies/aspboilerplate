(function ($) {
    var _categoriesAppServices = abp.services.app.category,
        l = abp.localization.getSource('omzo'),
        _$modal = $('#CategoryCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#CategoriesTable');

    var _$CategoriesTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _categoriesAppServices.getAll,
            inputFilter: function () {
                return $('#CategoriesSearchForm').serializeFormToObject(true);
            }
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$CategoriesTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            {
                targets: 0,
                className: 'control',
                defaultContent: '',
            },
            {
                targets: 1,
                data: 'name',
                sortable: false
            },
            {
                targets: 2,
                data: 'description',
                sortable: false
            },
            {
                targets: 3,
                data: 'Published',
                sortable: false,
                render: data => `<input type="checkbox" disabled ${data ? 'checked' : ''}>`
            },
            
            {
                targets: 4,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-category" data-category-id="${row.id}" data-toggle="modal" data-target="#CategoryEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-category" data-category-id="${row.id}" data-category-name="${row.name}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-secondary publish-category" data-category-id="${row.id}" data-category-name="${row.name}">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('publish')}`,
                        '   </button>'
                    ].join('');
                }
            }
        ]
    });

    _$form.find('.save-button').click(function (e) {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var category = _$form.serializeFormToObject();

        abp.ui.setBusy(_$modal);

        _categoriesAppServices
            .create(category)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$CategoriesTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });

    $(document).on('click', '.publish-category', function () {
        var categoryid = $(this).attr('data-category-id');
        var name = $(this).attr('data-category-name');

        activecategory(categoryid, name);
    });
    
    $(document).on('click', '.delete-category', function () {
        var categoryid = $(this).attr('data-category-id');
        var name = $(this).attr('data-category-name');

        deletecategory(categoryid, name);
    });

    $(document).on('click', '.edit-category', function (e) {
        var categoryid = $(this).attr('data-category-id');

        abp.ajax({
            url: abp.appPath + 'Categories/EditModal?categoryid=' + categoryid,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#CategoryEditModal div.modal-content').html(content);
            },
            error: function (e) {
            }
        });
    });

    abp.event.on('category.edited', (data) => {
        _$CategoriesTable.ajax.reload();
    });

    function activecategory(categoryid, name) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToActive'),
                name
            ),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _categoriesAppServices
                        .active({
                            id: categoryid
                        })
                        .done(() => {
                            abp.notify.info(l('Successfullyactive'));
                            _$CategoriesTable.ajax.reload();
                        });
                }
            }
        );
    }
    function deletecategory(categoryid, name) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                name
            ),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _categoriesAppServices
                        .delete({
                            id: categoryid
                        })
                        .done(() => {
                            abp.notify.info(l('SuccessfullyDeleted'));
                            _$CategoriesTable.ajax.reload();
                        });
                }
            }
        );
    }

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$CategoriesTable.ajax.reload();
    });

    $('.btn-clear').on('click', (e) => {
        $('input[name=Keyword]').val('');
        $('input[name=IsActive][value=""]').prop('checked', true);
        _$CategoriesTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$CategoriesTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
