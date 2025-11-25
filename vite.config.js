import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';
import tailwindcss from '@tailwindcss/vite';
import { resolve } from 'path';

// https://nojaf.com/vite-plugin-fable/recipes.html#Using-React
// https://nojaf.com/vite-plugin-fable/recipes.html#Fable-Core-JSX
export default defineConfig({
 plugins: [
    tailwindcss(),
    react({
        include: "/\.(js|jsx|ts|tsx)$/",
        jsxRuntime: "automatic"
    }),
 ],
 root: "./src",
 build: {
    outDir: "./dist",
    sourcemap: 'inline',
    rollupOptions: {
        input: {
            main: resolve(__dirname, './src/index.html'),
        },
        output: {
          entryFileNames: 'js/[name].[hash].js',
          chunkFileNames: 'js/[name].[hash].chunk.js',
          assetFileNames: '[ext]/[name].[hash].[ext]',
        },
      },
    minify: "oxc",
 }
})
