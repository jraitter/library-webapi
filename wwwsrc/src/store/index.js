import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";

Vue.use(Vuex);

let baseUrl = location.host.includes("localhost")
  ? "https://localhost:5001/"
  : "/";

let api = Axios.create({
  baseURL: baseUrl + "api",
  timeout: 3000,
  withCredentials: true
});

export default new Vuex.Store({
  state: {
    profile: {},
    books: [],
    activeBook: [],
    authors: [],
    activeAuthor: []
  },
  mutations: {
    setProfile(state, profile) {
      state.profile = profile;
    },
    setBooks(state, books) {
      state.books = books;
    },
    setAuthors(state, authors) {
      state.authors = authors;
    },
    setActiveAuthor(state, author) {
      state.activeAuthor = author;
    },
    setActiveBook(state, book) {
      state.activeBook = book;
    }
  },
  actions: {
    setBearer({ }, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },

    async getBooks({ commit, dispatch }) {
      let res = await api.get("books");
      commit("setBooks", res.data);
    },

    async getAuthors({ commit }) {
      let res = await api.get("authors");
      commit("setAuthors", res.data);
    },
    async getCurrentAuthor({ commit }, id) {
      let res = await api.get("books/" + id + "/authors");
      commit("setActiveAuthor", res.data)
    },
    async getCurrentBook({ commit }, id) {
      let res = await api.get("authors/" + id + "/books");
      commit("setActiveBook", res.data)
    },
    async createBook({ commit, dispatch }, payload) {
      let bookres = await api.post("books", payload);
      console.log("book-res", bookres.data);

      let authres = await api.post("authors", payload);
      console.log("auth-res", authres.data);


      let res = await api.post("bookauthors", { bookId: bookres.data.id, authId: authres.data.id });
      console.log("bookAuthor", res.data);

    }
  }
});
