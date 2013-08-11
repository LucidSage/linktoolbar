$(document).ready(function () {
    var data = [
    {
        "LinkId": 1,
        "Version": 1,
        "Name": "alsdkjf",
        "ImageSrc": "alsdkjf",
        "ImageAltText": "sadljk;f",
        "Target": 1,
        "TargetHref": "1",
        "Links": [
          {
              "LinkId": 2,
              "Version": 1,
              "Name": "CHILD",
              "ImageSrc": "LLL",
              "ImageAltText": "LLL",
              "Target": 1,
              "TargetHref": "1",
              "Links": null,
              "Visibility": 1
          }
        ],
        "Visibility": 1
    },
    {
        "LinkId": 2,
        "Version": 1,
        "Name": "CHILD",
        "ImageSrc": "LLL",
        "ImageAltText": "LLL",
        "Target": 1,
        "TargetHref": "1",
        "Links": null,
        "Visibility": 1
    }
    ];

    var parseMenu = function (links) {
        return $.map(links, function (link) {
            var l = {
                text: link.Name,
            };
            if (link.ImageSrc) l.imageUrl = link.ImageSrc;
            if (link.Links) l.items = parseMenu(link.Links);
            return l;
        });
    };

    //var transport = {
    //    read: {
    //        url: "/links",
    //        dataType: "json"
    //    }
    //};

    //var menuSource = new kendo.data.DataSource({
        //transport: transport,
        //schema: {
        //    data: function (data) {
        //        var parse = function (links) {
        //            return $.map(links, function (link) {
        //                return {
        //                    text: link.Name,
        //                    imageUrl: link.ImageSrc,
        //                    items: parse(link.Links)
        //                };
        //            });
        //        };

        //        return parse(data.Links);
        //    }
        //}
    //});

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
        dataSource: parseMenu(data),
        closeOnClick: false,
        openOnClick: true,
        select: function (e) {
        }
    });

    //$("#tree").kendoTreeview({
    //    datasource: treeSource,
    //    autobind: false
    //});
});