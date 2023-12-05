# How do I create a template?

## Requirements

-   Open the project in `vscode`.
-   `vscode` will recommend some extensions; please install them first.
-   Restart the `vscode`
-   Install all the node packages using the below command.
    ```
    npm install
    ```

## Template creation

-   In the `templates/assets/vendor/bootstrap` folder, I have customized the bootstrap and converted it to minimize bootstrap.

    **Note:** _bootstrap v3.x is required as `DinkToPdf` is limited to CSS properties._

-   I have created a boilerplate for the static template design. You have to copy it and design it under the `templates/resume` or `templates/cover-letter` folder, depending on the type of template you are designing.

-   After completing the static template design,

    -   Auto-prefix your CSS code using [Auto Prefixer](https://autoprefixer.github.io/).
    -   The `Browserslist` option should be
        ```
        >0.1%, last 10 version, IE 10
        ```

-   After that, you also have to format your code using the below command.

    ```
    npm run fmt
    ```

-   After that, you can create your `.cshtml` file. I have already provided a `.cshtml` template boilerplate in `templates/boilerplate`.

## Limitation

-   Your CSS property will not work for `DinkToPdf` if you are using the latest CSS properties. You can verify it via [Can I Use](https//caniuse.com) and check if the CSS property is supported in `IE 10`. If the CSS property is supported, then you can use it in you code.

-   The same goes for JavaScript as well. Do not use the **ES6** syntax of JavaScript. `DinkToPdf` only supports the **ES5** version of JavaScript.
-   I have created a `.cshtml` boilerplate. Here, I have created a `cssUrl` lamda function, which is needed because `DinkToPdf` always required a full URL, not the relative URL.
