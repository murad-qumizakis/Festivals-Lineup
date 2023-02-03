import { useState, useEffect } from 'react'
import '../src/ArtistForm.css'
import axios from 'axios'

export default function ArtistForm({onNewArtist}) {

    let [artistName, setArtistName] = useState('')
    let [country, setCountry] = useState('')
    let [festival, setFestival] = useState([])
    const [selectedFestival, setSelectedFestival] = useState(null);

    useEffect(() => {
        (async () => {
        const result = await axios.get("/api/festivals")
           setFestival(result.data)
       })()
       }, [])


    //    console.log('festivals ARTIST COMP: ', festival)

    function handleSubmit(e){
        e.preventDefault()
        onNewArtist(artistName, country, selectedFestival)
        console.log('selectedFestival: ', selectedFestival)
        setArtistName('')
        setCountry('')
        // setFestival('')
        console.log('submitted')
    }



  return (
    <div>
    <div className='artist-form'>
      <form onSubmit={handleSubmit}>
       <h3>Add Artist here!</h3> 
        <label htmlFor="festivalName">Artist name</label>
        <input value={artistName} onChange={e => {setArtistName(e.target.value)}} type="text" id="artistName" name="artistName" />

        <label htmlFor="country">Country</label>
        <input value={country} onChange={e => {setCountry(e.target.value)}} type="text" id="country" name="country" />

        <label htmlFor="festival">Festival:</label>
            <select id="festival" name="festival" value={selectedFestival} onChange={e => setSelectedFestival(e.target.value)}>
                <option value="">Select a festival</option>
                {festival.map(fest => {
                    return <option key={fest.id} value={fest.id}>{fest.name}</option>
                })}
            </select>

        <button type="submit">Submit</button>
      </form>
      </div>
    </div>
  )
}

