$(document).ready(function () {
    var transport = {
        read: {
            url: "/links",
            dataType: "json"
        }
    };

    var menuSource = new kendo.data.DataSource({
        transport: transport,
        schema: {
            data: function (data) {
                var parse = function (links) {
                    return $.map(links, function (link) {
                        return {
                            text: link.Name,
                            imageUrl: link.ImageSrc,
                            items: parse(link.Links)
                        };
                    });
                };

                return parse(data.Links);
            }
        }
    });

    //var treeSource = new kendo.data.HierarchicalDataSource({
    //    transport: transport,
    //    schema: {
    //        data: function (data) {
    //            var parse = function (links) {
    //                return $.map(links, function (link) {
    //                    return {
    //                        text: link.Name,
    //                        imageUrl: link.ImageSrc,
    //                        items: parse(link.Links)
    //                    };
    //                });
    //            };

    //            return parse(data.Links);
    //        }
    //    }
    //});

    $("#menu").kendoMenu({
        datasource: menuSource,
        autobind: false,
        closeOnClick: false,
        select: function (e) {
            // handle event
        }
    });

    //$("#tree").kendoTreeview({
    //    datasource: treeSource,
    //    autobind: false
    //});
});