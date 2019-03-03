const path = require('path');
const env = require('@babel/preset-env');
const reactApp = require('babel-preset-react-app');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
// Webpack build configuration to build the SSR bundle.
// Invoked by build:server.
const devMode = process.env.NODE_ENV !== 'production';

module.exports = {
  mode: 'production',
  entry: path.resolve(__dirname, './server.js'),
  target: 'node',
  output: {
    path: path.resolve(__dirname, '../build'),
    filename: '../build/server.bundle.js',
    libraryTarget: 'this',
  },
  optimization: {
    minimize: false,
  },
  plugins: [
    new MiniCssExtractPlugin({
      // Options similar to the same options in webpackOptions.output
      // both options are optional
      filename: devMode ? '[name].css' : '[name].[hash].css',
      chunkFilename: devMode ? '[id].css' : '[id].[hash].css',
    })
  ],
  module: {
    rules: [
      {
        test: /\.m?jsx?$/,
        exclude: /node_modules/,
        use: {
          loader: 'babel-loader',
          options: {
            babelrc: false,
            presets: [env, reactApp],
          },
        },
      },
      {
        test: /\.html$/,
        exclude: /node_modules/,
        use: { loader: 'html-loader' },
      },
      {
        // anything not JS or HTML, we load as a URL
        // this makes static image imports work with SSR
        test: /\.(?!js|mjs|jsx|html|graphql|scss|css$)[^.]+$/,
        exclude: /node_modules/,
        use: {
          loader: 'url-loader',
        },
      },
      {
        // anything in node_modules that isn't js,
        // we load as null - e.g. imported css from a module,
        // that is not needed for SSR
        test: /\.(?!js|mjs|jsx|html|graphql|scss|css$)[^.]+$/,
        include: /node_modules/,
        use: {
          loader: 'null-loader',
        },
      },
      {
        test: /\.(css|scss)?$/,
        use: [
          devMode ? 'style-loader' : MiniCssExtractPlugin.loader, // creates style nodes from JS strings
          {
            loader: 'css-loader' // translates CSS into CommonJS
          },
          {
            loader: 'sass-loader', // compiles Sass to CSS, using Node Sass by default
            options: {
              includePaths: ['node_modules']
            }
          }
        ]
      }
    ],
  },
};
