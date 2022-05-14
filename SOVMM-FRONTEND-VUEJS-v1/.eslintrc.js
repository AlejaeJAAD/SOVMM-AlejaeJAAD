module.exports = {
  root: true,
  env: {
    node: true
  },
  extends: ["plugin:vue/essential", "@vue/airbnb"],
  parserOptions: {
    parser: "babel-eslint"
  },
  plugins: ["vuetify"],
  rules: {
    quotes: [0, "double"],
    "linebreak-style": ["error", process.platform === "win32" ? "windows" : "unix"],
    "no-console": process.env.NODE_ENV === "production" ? "warn" : "off",
    "no-debugger": process.env.NODE_ENV === "production" ? "warn" : "off",
    "import/extensions": "off",
    "vuetify/no-deprecated-classes": "error",
    "vuetify/grid-unknown-attributes": "error",
    "vuetify/no-legacy-grid": "error",
    "vue/self-closing-comp": "off",
    "vue/self-closing-comp": "off",
    "no-shadow": ["error", { allow: ["state"] }],
    "no-param-reassign": [
      "error",
      {
        props: true,
        ignorePropertyModificationsFor: [
          // All properties except state are in the ignorePropertyModificationsFor array by default.
          "state",
          "acc",
          "e",
          "ctx",
          "req",
          "request",
          "res",
          "response",
          "$scope"
        ]
      }
    ]
  }
};
