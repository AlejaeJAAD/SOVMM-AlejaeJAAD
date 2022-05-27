<template>
  <v-main>
    <div>
      <v-app-bar color="grey lighten-4" tile fixed elevation="1" dense>
        <v-btn text color="black" @click.stop="drawer = !drawer">
          Menu
          <v-icon size="40" v-if="!drawer">mdi-chevron-right</v-icon>
        </v-btn>
        <v-spacer></v-spacer>
      </v-app-bar>
      <v-navigation-drawer width="250px" app temporary v-model="drawer" color="grey lighten-4">
        <template v-slot:prepend>
          <v-list-item two-line class="px-2">
            <v-list-item-avatar color="grey">
              <v-img :src="user.image" />
            </v-list-item-avatar>

            <v-list-item-content>
              <v-list-item-title v-text="name"></v-list-item-title>
              <v-list-item-subtitle>Logueado</v-list-item-subtitle>
            </v-list-item-content>
            <v-btn icon style="color: black" @click.stop="drawer = !drawer">
              <v-icon size="30" v-if="drawer">mdi-chevron-left</v-icon>
            </v-btn>
          </v-list-item>
        </template>
        <v-divider></v-divider>

        <v-list nav shaped dense>
          <v-list-item-group>
            <v-list-item @mouseenter="item.hovered = true" color="black" v-for="item in items" :key="item.title" :to="item.to" class="item">
              <v-list-item-icon>
                <v-icon>{{ item.icon }}</v-icon>
              </v-list-item-icon>
              <v-list-item-content>
                <v-list-item-title>{{ item.title }}</v-list-item-title>
              </v-list-item-content>
            </v-list-item>
          </v-list-item-group>
        </v-list>
        <template v-slot:append>
          <div class="pa-2">
            <v-btn color="black" block outlined @click="$store.dispatch('logOut').then($router.push('/login'))"> Cerrar Sesion <v-icon>mdi-logout</v-icon> </v-btn>
          </div>
        </template>
      </v-navigation-drawer>
    </div>
  </v-main>
</template>

<script>
export default {
  name: "Nav",
  data() {
    return {
      drawer: false,
      searchQuery: "",
      cancelQueryBtn: false,
      searchBox: false
    };
  },
  methods: {
    search() {
      this.searchBox = false;
      this.$router.replace({ path: this.$route.path, query: { s: this.searchQuery } }).catch(() => ({ s: this.searchQuery }));
      this.searchQuery = "";
    },
    cancelQuery() {
      this.cancelQueryBtn = false;
      this.$router.replace(this.$route.path).catch(() => "");
      this.$router.go();
    }
  },
  watch: {
    $route(to) {
      if (to.query.s && to.query.toString().length > 0) {
        this.$router.go();
        this.cancelQueryBtn = true;
        this.searchQuery = "";
      } else {
        this.cancelQuery();
      }
    }
  },
  computed: {
    user() {
      return this.$store.getters.getUser || { firstName: "Jose", lastName: "Lopez", image: "" };
    },
    name() {
      const user = this.$store.getters.getUser;
      const fName = user.firstName || "";
      const lName = user.lastName || "";
      return `${fName.split(" ")[0]} ${lName.split(" ")[0]}`;
    },
    items() {
      const items = [
        {
          title: "Inicio",
          icon: "mdi-rss",
          to: "/inicio",
          hovered: false
        }
      ];
      if (this.$store.getters.getUser.accessLevel === 1) {
        items.push(
          {
            title: "Mi cuenta",
            icon: "mdi-account",
            to: "/cuenta",
            hovered: false
          },
          {
            title: "Proyectos Residencias",
            icon: "mdi-text-box-multiple",
            to: "/proyectos-alumnos",
            hovered: false
          },
          {
            title: "Estudiantes",
            icon: "mdi-account-group",
            to: "/estudiantes",
            hovered: false
          },
          {
            title: "Maestros",
            icon: "mdi-school",
            to: "/maestros",
            hovered: false
          }
        );
      }
      if (this.$store.getters.getUser.accessLevel === 2) {
        items.push(
          {
            title: "Mi cuenta",
            icon: "mdi-account",
            to: "/cuenta",
            hovered: false
          },
          {
            title: "Proyectos Residencias",
            icon: "mdi-text-box-multiple",
            to: "/proyectos-alumnos",
            hovered: false
          }
        );
      }
      if (this.$store.getters.getUser.accessLevel === 3) {
        items.push(
          {
            title: "Mi cuenta",
            icon: "mdi-account",
            to: "/cuenta",
            hovered: false
          },
          {
            title: "Proyecto de residencias",
            icon: "mdi-home-city",
            to: "/mi-proyecto",
            hovered: false
          }
        );
      }
      return items;
    }
  },
  mounted() {
    if (this.$route.query.s) {
      this.cancelQueryBtn = true;
    }
    this.$nextTick(() => {});
  }
};
</script>

<style scoped>
.item:hover {
  background-color: rgba(0, 0, 0, 0.2) !important;
}
</style>
