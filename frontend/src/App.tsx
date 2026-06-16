import React from 'react';
import Navbar from './layouts/Navbar';
import Sidebar from './layouts/Sidebar';
import WorkoutCard from './components/WorkoutCard';
import useLocalStorage from './hooks/useLocalStorage';
import Login from './pages/Login'; // Móc file Login vào đây

function App() {
  // 1. Dùng Hook lưu trạng thái Đăng nhập. Mặc định là false (Chưa đăng nhập)
  const [isLoggedIn, setIsLoggedIn] = useLocalStorage<boolean>('auth-status', false);

  const [theme, setTheme] = useLocalStorage<'light' | 'dark'>('app-theme', 'dark');
  const [targetStyle, setTargetStyle] = useLocalStorage<string>('user-target-style', 'Baki Hanma');

  // 2. LOGIC CỔNG AN NINH: Nếu chưa đăng nhập, BẮT BUỘC hiển thị trang Login
  if (!isLoggedIn) {
    return <Login onLoginSuccess={() => setIsLoggedIn(true)} />;
  }

  // 3. Nếu đã đăng nhập thành công, thả cửa cho vào Dashboard
  const isDark = theme === 'dark';
  const bgColor = isDark ? '#121212' : '#f4f4f4';
  const textColor = isDark ? '#ffffff' : '#333333';

  return (
    <div style={{ display: 'flex', flexDirection: 'column', height: '100vh', margin: 0, fontFamily: 'sans-serif' }}>
      <Navbar />

      <div style={{ display: 'flex', flex: 1 }}>
        {/* Trên Mobile, cái Sidebar này sau này mình sẽ giấu đi thành menu Hamburger, tạm thời cứ để đó */}
        <Sidebar />

        <main style={{ flex: 1, padding: '20px', background: bgColor, color: textColor, transition: 'all 0.3s ease' }}>
          <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
            <h2>Dashboard Huấn Luyện</h2>

            {/* Nút Đăng xuất (Đổi State về false là tự động văng ra màn hình Login) */}
            <button
              onClick={() => setIsLoggedIn(false)}
              style={{ padding: '8px 16px', cursor: 'pointer', borderRadius: '5px', background: '#e50914', color: '#fff', border: 'none' }}
            >
              Đăng xuất
            </button>
          </div>

          <div style={{ marginTop: '20px' }}>
            <p>Mục tiêu hiện tại của bạn: <strong>{targetStyle}</strong></p>
          </div>

          <div style={{ display: 'flex', gap: '20px', marginTop: '30px' }}>
            <WorkoutCard planName="Giáo án Sức mạnh" animeStyle={targetStyle} days={5} />
          </div>
        </main>
      </div>
    </div>
  );
}

export default App;