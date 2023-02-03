import './App.css'
import { useState, useEffect } from 'react'
import FestivalForm from '../components/FestivalForm'
import ArtistForm from '../components/ArtistForm'
import Festivals from '../components/Festivals'
import axios from 'axios'


function App() {
  const [festivals, setFestivals] = useState([])

  useEffect(() => {
   (async () => {
   const result = await axios.get("/api/festivals")
      setFestivals(result.data)
  })()
  }, [])

  


  async function handleNewFestival(festivalName, date, location, genre) {
     await axios.post("/api/festivals/create", {
      name: festivalName,
      date,
      location,
      genre
    })
    .then(res => {
      setFestivals([res.data, ...festivals])
    })
    .catch(err => {
      console.log(err)
    })  
}

async function handleNewArtist(artistName, country, festivalid) {
  await axios.post("/api/artists/create", {
    name: artistName,
    country,
    festivalid
  })
  .then(res => {
    setFestivals(festivals => festivals.map(festival => {
      if (festival.id === res.data.id) {
        return res.data
      } else {
        return festival
      }
    }))
    // setFestivals([res.data, ...festivals])
  })
  .catch(err => {
    console.log(err)
  })
}

console.log("festivals", festivals)


  return (
    <div className="App">

    
      <FestivalForm onNewFestival={handleNewFestival}/>
      <ArtistForm onNewArtist={handleNewArtist}/>

        <div className="cards">
            <h1>Festivals</h1>
            <div className="festivals">
              {festivals.sort().map((festival) => (
                <Festivals key={festival.id} festival={festival}/>
              ))}
            </div>
        </div>

       
    </div>
  )

}

export default App
