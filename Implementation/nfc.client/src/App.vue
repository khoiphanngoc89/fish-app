<template>
  <div id="app">
    <router-view/>
  </div>
</template>

<script>
export default {
  metaInfo: {
      // if no subcomponents specify a metaInfo.title, this title will be used
      title: 'Home',
      // all titles will be injected into this template
      titleTemplate: '%s - Florida Fish'
  }
}
</script>