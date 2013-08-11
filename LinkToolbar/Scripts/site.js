$(document).ready(function () {
    var source;

    var parseMenu = function (links) {
        var map = $.map(links, function (link) {
            var l = {
                id: link.LinkId,
                text: link.Name
            };
            if (link.ImageSrc) l.imageUrl = link.ImageSrc;
            if (link.Links) {
                console.log("links found.");
                l.items = parseMenu(link.Links);
            }
            return l;
        });
        return map;
    };

    var transport = {
        read: {
            url: "/api/link",
            dataType: "json"
        }
    };

    var menuSource = new kendo.data.DataSource({
        transport: transport,
        schema: {
            data: function (data) {
                source = data;
                return parseMenu(data);
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

    var menu = $("#menu").kendoMenu({
        dataSource: menuSource,
        closeOnClick: false,
        select: function (e) {
            console.log(e);
        }
    });

    //menuSource.read();

    //$("#tree").kendoTreeview({
    //    datasource: treeSource,
    //    autobind: false
    //});
});