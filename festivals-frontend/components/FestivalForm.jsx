import { useState } from 'react'
import '../src/FestivalForm.css'

export default function FestivalForm({onNewFestival}) {

    let [festivalName, setFestivalName] = useState('')
    let [date, setDate] = useState('')
    let [location, setLocation] = useState('')
    let [genre, setGenre] = useState('')


    function handleSubmit(e){
        e.preventDefault()
        onNewFestival(festivalName, date, location, genre)
        setFestivalName('')
        console.log('submitted')
    }



  return (
    <div>
    <div className='fest-form'>
      <form onSubmit={handleSubmit}>
       <h3>Add Festival here!</h3> 
        <label htmlFor="festivalName">Festival name</label>
        <input value={festivalName} onChange={e => {setFestivalName(e.target.value)}} type="text" id="festivalName" name="festivalName" />

        <label htmlFor="date">Date</label>
        <input value={date} onChange={e => {setDate(e.target.value)}} type="date" id="date" name="date" />

        <label htmlFor="location">Location</label>
        <input value={location} onChange={e => {setLocation(e.target.value)}} type="text" id="location" name="location" />

        <label htmlFor="genre">Genre</label>
        <input value={genre} onChange={e => {setGenre(e.target.value)}} type="text" id="genre" name="genre" />

        
        <button type="submit">Submit</button>
      </form>
      </div>
    </div>
  )
}

