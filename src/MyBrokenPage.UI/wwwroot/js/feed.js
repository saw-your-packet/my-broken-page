$(document).ready(function () {
    formatQuery();
});

injectHtml = function (query, searchInput) {
    let searchValueIndex = query.indexOf("(") + 1;

    return query.slice(0, searchValueIndex) + searchInput + query.slice(searchValueIndex);
};

reinterpretQuery = function (query) {
    let $newHtmlCodeElement = $(`<code class="html">${query}</code>`);

    $htmlCodeElement.find("code").remove();
    $htmlCodeElement.text("\n");
    $htmlCodeElement.append($newHtmlCodeElement);

    document.querySelectorAll("pre code").forEach((block) => {
        hljs.highlightBlock(block);
    });
};

formatQuery = function () {
    $searchInputElement = $("#SearchObject_SearchInput");

    if ($searchInputElement.length === 0) {
        return;
    }

    $htmlCodeElement = $("#html-window>pre");

    if ($htmlCodeElement.length === 0) {
        return;
    }

    $searchInputElement.keyup(function () {
        let partialQuery = injectHtml(HTML_RAW, $searchInputElement.val());
        partialQuery = partialQuery.replace(/&/g, "&amp;")
            .replace(/</g, "&lt;")
            .replace(/>/g, "&gt;")
            .replace(/"/g, "&quot;")
            .replace(/'/g, "&#039;");

        reinterpretQuery(partialQuery);
    });
};
