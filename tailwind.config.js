/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./src/components/**/*.fs.js",
        "./src/**/*.fs.js",
        "./src/index.html"
    ],
    theme: {
        extend: {},
    },
    plugins: [require("daisyui")],
}
