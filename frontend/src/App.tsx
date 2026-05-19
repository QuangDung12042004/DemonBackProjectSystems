import { useState, useEffect } from 'react'
import './App.css'

function App() {
  const [healthStatus, setHealthStatus] = useState<string>('Checking...')
  const [workoutPlan, setWorkoutPlan] = useState<any>(null)
  const [loading, setLoading] = useState(false)

  // Cổng Backend .NET của bạn đang là 5079
  const BACKEND_URL = 'http://localhost:5079'

  useEffect(() => {
    // 1. Gọi API Health Check
    fetch(`${BACKEND_URL}/api/health`)
      .then(res => res.json())
      .then(data => {
        setHealthStatus(`${data.service} is ${data.status}`)
      })
      .catch(err => {
        console.error(err)
        setHealthStatus('Failed to connect to Backend')
      })
  }, [])

  const handleGeneratePlan = async () => {
    setLoading(true)
    try {
      // 2. Gọi API Generate Workout
      const response = await fetch(`${BACKEND_URL}/api/workout/generate`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          goal: "Build Muscle",
          level: "Beginner",
          days_per_week: 3,
          anime_style: "Goku"
        })
      })

      if (!response.ok) throw new Error('API Error')

      const data = await response.json()
      setWorkoutPlan(data)
    } catch (err) {
      console.error(err)
      alert('Lỗi khi gọi API. Kiểm tra console F12.')
    } finally {
      setLoading(false)
    }
  }

  return (
    <div style={{ padding: '20px', fontFamily: 'sans-serif', maxWidth: '600px', margin: '0 auto' }}>
      <h1 style={{ color: '#fff' }}>AnimeFit Pro - API Tester</h1>

      <div style={{ marginBottom: '20px', padding: '15px', backgroundColor: '#333', borderRadius: '8px' }}>
        <h3 style={{ margin: 0, color: '#fff' }}>
          Backend Status: <span style={{ color: healthStatus.includes('running') ? '#4ade80' : '#f87171' }}>{healthStatus}</span>
        </h3>
      </div>

      <button
        onClick={handleGeneratePlan}
        disabled={loading}
        style={{
          padding: '12px 24px',
          fontSize: '16px',
          cursor: loading ? 'not-allowed' : 'pointer',
          backgroundColor: '#646cff',
          color: 'white',
          border: 'none',
          borderRadius: '8px',
          fontWeight: 'bold'
        }}
      >
        {loading ? 'Đang tạo kế hoạch...' : 'Generate Workout Plan'}
      </button>

      {workoutPlan && (
        <div style={{ marginTop: '20px', padding: '20px', backgroundColor: '#1a1a1a', borderRadius: '8px', textAlign: 'left' }}>
          <h3 style={{ marginTop: 0, color: '#fff' }}>Generated Workout Plan:</h3>
          <pre style={{ whiteSpace: 'pre-wrap', color: '#4ade80', fontSize: '14px', margin: 0 }}>
            {JSON.stringify(workoutPlan, null, 2)}
          </pre>
        </div>
      )}
    </div>
  )
}

export default App
