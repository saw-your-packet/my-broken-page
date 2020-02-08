$(document).ready(function () {
    formatQuery();
});

injectUsername = function (query, username) {
    let usernameValueIndex = query.indexOf("'") + 1;

    return query.slice(0, usernameValueIndex) + username + query.slice(usernameValueIndex);
};

injectPassword = function (query, password) {
    let searchSubstring = "Password = '";
    let passwordValueIndex = query.lastIndexOf(searchSubstring) + searchSubstring.length;

    return query.slice(0, passwordValueIndex) + password + query.slice(passwordValueIndex);
};

reinterpretQuery = function (query) {
    let $newSqlQueryElement = $(`<code class="sql">${query}</code>`);

    $sqlQueryParrentElement.find("code").remove();
    $sqlQueryParrentElement.text("\n");
    $sqlQueryParrentElement.append($newSqlQueryElement);

    document.querySelectorAll("pre code").forEach((block) => {
        hljs.highlightBlock(block);
    });
};

formatQuery = function () {
    $usernameInputElement = $("#login-username-input");
    $passwordInputElement = $("#login-password-input");

    if ($usernameInputElement.length === 0 || $passwordInputElement.length === 0) {
        return;
    }

    $sqlQueryParrentElement = $("#smss-window>pre");

    if ($sqlQueryParrentElement.length === 0) {
        return;
    }

    $usernameInputElement.keyup(function () {
        let partialQuery = injectUsername(SQL_BASE_QUERY, $usernameInputElement.val());
        let fullQuery = injectPassword(partialQuery, $passwordInputElement.val());

        reinterpretQuery(fullQuery);
    });

    $passwordInputElement.keyup(function () {
        let partialQuery = injectPassword(SQL_BASE_QUERY, $passwordInputElement.val());
        let fullQuery = injectUsername(partialQuery, $usernameInputElement.val());

        reinterpretQuery(fullQuery);
    });
};
