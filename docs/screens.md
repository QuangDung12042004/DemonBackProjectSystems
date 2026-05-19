# Phân Tích Màn Hình & UX/UI Flow (Screens) - AnimeFit Pro

Dưới đây là danh sách chi tiết các màn hình (Screens) cần xây dựng, kèm theo phân tích luồng người dùng (User Journey) và các yếu tố Anime/Gamification được lồng ghép.

## 1. Landing Page (Trang chủ giới thiệu)
**Mục tiêu**: Hook người dùng ngay từ giây đầu tiên. Thể hiện rõ tinh thần "Tập luyện để trở thành nhân vật chính".
**Các thành phần chính**:
- **Hero Section**: Background là video/ảnh nghệ thuật Anime cường độ cao. Tiêu đề lớn (Typography mạnh mẽ) + Nút CTA "Awaken Your Power" (Bắt đầu ngay).
- **Bảng chỉ số (Mockup)**: Một hình ảnh điện thoại hoặc laptop mockup hiển thị Dashboard của app.
- **Tính năng (Features)**: Giới thiệu các chức năng cốt lõi (Auto-Schedule, Workout Tracking, Body Transformation).
- **Anime Body Goals**: Slider giới thiệu các form người (Bulky như Goku, Shredded như Baki, Lean như Levi).

## 2. Authentication Flow (Đăng Nhập / Đăng Ký)
**Mục tiêu**: Mượt mà, nhanh chóng, giao diện Dark/Neon hiện đại.
**Các thành phần chính**:
- Nút đăng nhập qua Google/Github (OAuth).
- Form Email & Password (Có kiểm tra Validation trực tiếp).
- **Hiệu ứng**: Khi nhập đúng form, viền input phát sáng (Neon glow).

## 3. Onboarding Flow (Hành trình thức tỉnh - Thiết lập ban đầu)
**Mục tiêu**: Thu thập đủ data để AI có thể sinh lịch tập. Tạo cảm giác hào hứng như lúc tạo nhân vật trong game RPG.
**Các bước (Step-by-step Wizard)**:
1. **Chỉ số cơ thể**: Nhập chiều cao (Height), Cân nặng (Weight), Tuổi (Age), Giới tính.
2. **Kinh nghiệm**: Chọn Level (Tân thủ - Beginner, Chiến binh - Intermediate, Bậc thầy - Advanced).
3. **Lựa chọn Class (Goal)**: Chọn mục tiêu (Giảm mỡ, Tăng cơ, Duy trì).
4. **Target Anime Body**: Đây là tính năng "Killer" của app. Chọn phong cách form người Anime bạn muốn hướng tới. Mỗi form sẽ có minh hoạ đồ hoạ xịn xò.
5. Xử lý (Loading Screen): "Đang tính toán tiềm năng..." -> Chuyển vào Dashboard.

## 4. Main Dashboard (Trung tâm điều khiển)
**Mục tiêu**: Tổng hợp nhanh những gì User cần làm trong ngày hôm nay.
**Các thành phần chính**:
- **Greeting**: "Chào buổi sáng, Chiến binh [Tên]".
- **Today's Mission (Buổi tập hôm nay)**: Tên buổi tập (VD: Leg Day). Nút "Start Workout" thật to, nổi bật.
- **Weekly Streak**: Hiển thị số ngày đã tập trong tuần (VD: 🔥 3/5 ngày).
- **Progress Snapshot**: Biểu đồ nhỏ góc màn hình hiển thị sự thay đổi cân nặng gần nhất.
- **Current Anime Goal Card**: Nhắc nhở về hình mẫu body đang hướng tới.

## 5. Workout Tracking (Giao diện trong phòng tập - In-Gym Mode)
**Mục tiêu**: Phải dễ thao tác nhất có thể, chữ to, nút to, vì trong phòng tập mồ hôi nhiều và mỏi tay.
**Các thành phần chính**:
- **Header**: Đồng hồ đếm giờ tổng cộng. Nút Kết thúc (Finish).
- **Danh sách bài tập (Exercise List)**: Trượt dọc mượt mà.
- **Set/Rep Tracker**: 
  - Mỗi bài tập sẽ xổ ra các dòng (Sets). 
  - Cho phép nhập Weight (kg) và Reps (Số lần) thực tế đẩy được.
  - Checkbox to để đánh dấu "Hoàn thành".
- **Rest Timer (Đồng hồ đếm ngược lúc nghỉ)**: Tự động popup sau khi tick xong 1 set. (VD: Nghỉ 90s).
- **Hiệu ứng**: Khi ấn Kết thúc, màn hình "Mission Cleared" hiện ra với đánh giá (Rank S, Rank A, Rank B).

## 6. Lịch Tập Luyện (Workout Plan / Calendar)
**Mục tiêu**: Xem bức tranh toàn cảnh về kế hoạch.
**Các thành phần chính**:
- **Calendar View**: Đánh dấu các ngày có lịch tập và các ngày đã tập hoàn thành.
- **Plan Details**: Liệt kê chi tiết các bài trong 1 ngày bất kỳ. Có nút Edit để người dùng tự điều chỉnh (Đổi bài tập).
- **Exercise Library Modal**: Khi user muốn đổi bài tập, một popup danh sách bài tập (Kèm video/ảnh hướng dẫn) hiện ra để chọn.

## 7. Theo Dõi Tiến Độ (Body Progression / Analytics)
**Mục tiêu**: Cung cấp dữ liệu để User thấy mình đang tiến bộ.
**Các thành phần chính**:
- **Volume Graph**: Biểu đồ cho thấy mức tạ tổng cộng người dùng nâng được qua từng tuần đang đi lên (Progressive Overload).
- **Body Stats Log**: Nơi nhập cân nặng, vòng ngực, vòng tay mới.
- **Photo Transformation**: Thư viện ảnh mặt trước/sau của cơ thể qua các tháng để so sánh (Before/After Slider).

## 8. Gamification & Achievements (Hồ sơ & Thành tựu)
**Mục tiêu**: Giữ chân người dùng.
**Các thành phần chính**:
- Profile Card (Giống thẻ bài / Player Card trong game).
- Danh sách Huy hiệu (Badges) đã mở khoá (Sáng lên) và chưa mở khoá (Đen trắng).
- Bảng xếp hạng (Tùy chọn - Phase 2).