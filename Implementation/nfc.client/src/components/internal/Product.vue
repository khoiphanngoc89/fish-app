<template>
  <section>
    <b-field>
        
    </b-field>
    <b-field>
      <b-upload v-model="dropFiles" drag-drop>
        <section class="section">
          <div class="content has-text-centered">
            <p>
              <b-icon icon="upload" size="is-large"></b-icon>
            </p>
            <p>Drop your files here or click to upload</p>
          </div>
        </section>
      </b-upload>
    </b-field>
    <div class="tags">
      <span v-for="(file, index) in dropFiles" :key="index" class="tag is-primary">
        {{file.name}}
        <button class="delete is-small" type="button" @click.prevent="uploadFiles"></button>
      </span>
    </div>
  </section>
</template>

<script>
import firebase from "@/plugins/firebase";
export default {
  data() {
    return {
      mode: null,
      dropFiles: []
    };
  },
  methods: {
    uploadFiles: async function() {
      let self = this;
      this.dropFiles.map(file => {
        return self.upload(file);
      });
    },
    upload: async function(context) {
      // Create a root reference
      let storageRef = firebase.storage().ref();

      // Create a reference to 'mountains.jpg'
      let mountainsRef = await storageRef
        .child(context.fileName)
        .put(context.file);

      return mountainsRef;
    }
  }
};
</script>

<style>
</style>