const { defineConfig } = require("vite");
const react = require("@vitejs/plugin-react");

export default defineConfig({
    plugins: [react()],
    root: "src",
    build: {
        outDir: "../public",
        emptyOutDir: true,
        sourcemap: true
    }
});